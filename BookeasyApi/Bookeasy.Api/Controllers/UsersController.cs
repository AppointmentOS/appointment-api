using Bookeasy.Api.RequestSchemas;
using Bookeasy.Application.Users.Commands.CreateUser;
using Bookeasy.Application.Users.Queries.GetUserDetail;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Bookeasy.Api.Controllers
{
    public class UsersController : BaseController
    {
        public UsersController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// Create new user
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateNewUser(NewUserDto newUser)
        {
            try
            {
                var result = await Mediator.Send(new CreateUserCommand
                {
                    Email = newUser.Email,
                    Password = newUser.Password,
                    FirstName = newUser.FirstName,
                    LastName = newUser.LastName
                });
                if (result.Success)
                    return Created("", result.Payload);
                return BadRequest(new ProblemDetails()
                {
                    Detail = result.Error.Message,
                    Title = result.Error.GetType().Name
                });
            }
            catch (ArgumentException e)
            {
                return BadRequest();
            }
        }
    }
}
