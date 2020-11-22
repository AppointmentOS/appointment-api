using Bookeasy.Application.Common.Interfaces;
using Bookeasy.Domain.Entities;
using Bookeasy.Infrastructure.Identity;
using MongoDB.Bson;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Bookeasy.Infrastructure.Test
{
    [TestFixture]
    public class UserManagerServiceTest
    {
        [Test]
        public async Task CreateUserTest()
        {
            var user = new BusinessUser()
            {
                Email = "sample@email.com"
            };
            var password = "password";

            var userMock = new Mock<IBusinessUserRepository>();
            userMock.Setup(u => u.InsertOneAsync(It.IsAny<BusinessUser>()));
            var refreshTokenRepoMock = new Mock<IMongoRepository<RefreshToken>>();

            var tokenGeneratorMock = new Mock<IAuthenticationTokenGenerator>();

            var manager =
                new UserManagerService(userMock.Object, refreshTokenRepoMock.Object, tokenGeneratorMock.Object);
            var result = await manager.CreateUserAsync(user, password);
            Assert.NotNull(result);
        }
    }
}
