using Bookeasy.Api.Controllers;
using MediatR;
using Moq;
using NUnit.Framework;

namespace Bookeasy.Api.Test.Controllers
{
    using Application.Common.Models;
    using Application.Users.Commands.CreateUser;
    using Application.Users.Queries.GetUserDetail;
    using DTOs;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading;
    using System.Threading.Tasks;

    [TestFixture]
    public class UsersControllerTest
    {
        private UsersController _usersController;
        private readonly Mock<IMediator> _mediator = new Mock<IMediator>();

        [SetUp]
        public void SetUp()
        {
            _usersController = new UsersController(_mediator.Object);
        }

        [Test]
        public async Task CreateNewUser_ValidInput_ShouldReturnCreatedResult()
        {
            _mediator.Setup(x => x.Send(It.IsAny<CreateUserCommand>(), CancellationToken.None))
                .ReturnsAsync(CQRSResult<UserDto>.CreateSuccessResult(new UserDto()
                {
                    Email = "johndoe@gmail.com"
                }));

            var result = await _usersController.CreateNewUser(new NewUserDto()) as CreatedResult;

            Assert.NotNull(result);

            var newUser = result.Value as UserDto;
            Assert.NotNull(newUser);
            Assert.AreEqual("johndoe@gmail.com", newUser.Email);
        }
    }
}
