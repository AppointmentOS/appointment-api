using Bookeasy.Application.Common.Models;
using Bookeasy.Domain.Entities;
using System.Threading.Tasks;

namespace Bookeasy.Application.Common.Interfaces
{
    public interface IUserManager
    {
        Task<BusinessUser> CreateUserAsync(BusinessUser businessUser, string password);

        Task DeleteUserAsync(string userId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Token and refresh token</returns>
        /// <exception cref="AuthenticationException">Email or password mismatch</exception>
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task<RefreshTokenResponse> RefreshToken(string userId, string token, string ipAddress);
    }
}
