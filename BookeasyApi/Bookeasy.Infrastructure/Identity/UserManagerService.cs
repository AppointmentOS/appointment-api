using Bookeasy.Application.Common.Interfaces;
using Bookeasy.Application.Common.Models;
using Bookeasy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Security.Claims;
using System.Threading.Tasks;
using Bookeasy.Application.Common.Exceptions;
using MongoDB.Bson;

namespace Bookeasy.Infrastructure.Identity
{
    public class UserManagerService : IUserManager
    {
        private readonly IBusinessUserRepository _businessUserRepository;
        private readonly IMongoRepository<RefreshToken> _refreshTokenRepository;
        private readonly IAuthenticationTokenGenerator _authenticationTokenGenerator;

        public UserManagerService(IBusinessUserRepository businessUserRepository,
            IMongoRepository<RefreshToken> refreshTokenRepository,
            IAuthenticationTokenGenerator authenticationTokenGenerator)
        {
            _businessUserRepository = businessUserRepository;
            _refreshTokenRepository = refreshTokenRepository;
            _authenticationTokenGenerator = authenticationTokenGenerator;
        }

        public async Task<BusinessUser> CreateUserAsync(BusinessUser businessUser, string password)
        {
            // check for existing user
            var salt = PasswordHasherUtility.CreateSalt();
            businessUser.PasswordSalt = salt;
            businessUser.PasswordHash = PasswordHasherUtility.HashPassword(password, salt);
            await _businessUserRepository.InsertOneAsync(businessUser);
            return businessUser;
        }

        public async Task DeleteUserAsync(string userId)
        {
            var foundUser = await _businessUserRepository.FindByIdAsync(userId);
            if (foundUser == null)
                throw new InvalidOperationException("User not found");
            await _businessUserRepository.DeleteOneAsync(user => user.Id == ObjectId.Parse(userId));
        }

        public async Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request)
        {
            var user = await _businessUserRepository.FindOneAsync(_ => _.Email == request.Email);
            if (user == null)
                throw new NotFoundException(nameof(BusinessUser), request.Email);
            var isValid = PasswordHasherUtility.VerifyPassword(request.Password, user.PasswordSalt, user.PasswordHash);
            if (isValid)
                return new AuthenticationResponse
                {
                    Email = user.Email,
                    JwtToken = _authenticationTokenGenerator.GenerateToken(new List<Claim>
                    {
                        new Claim("UserId", user.Id.ToString())
                    }),
                    RefreshToken = _authenticationTokenGenerator
                        .GenerateRefreshToken(user.Id.ToString(), request.IpAddress).Token
                };

            throw new AuthenticationException("Invalid email or password");
        }

        public async Task<RefreshTokenResponse> RefreshToken(string userId, string token, string ipAddress)
        {
            var oldToken = await _refreshTokenRepository.FindOneAsync(_ => _.Token == token);

            // return null if token is no longer active
            if (!oldToken.IsActive) return null;

            var refreshToken = _authenticationTokenGenerator.GenerateRefreshToken(userId, ipAddress);

            // revoke old token
            oldToken.Revoked = DateTime.UtcNow;
            oldToken.RevokedByIp = ipAddress;
            oldToken.ReplacedByToken = refreshToken.Token;

            // save new token
            await _refreshTokenRepository.InsertOneAsync(refreshToken);

            // generate new jwt
            var accessToken = _authenticationTokenGenerator.GenerateToken(new List<Claim>()
            {
                new Claim("UserId", userId)
            });

            return new RefreshTokenResponse
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken.Token
            };
        }
    }
}
