using Bookeasy.Api.DTOs;
using Bookeasy.Api.RequestSchemas;
using Bookeasy.Application.BusinessUsers.Commands;
using Bookeasy.Application.BusinessUsers.Queries;
using Bookeasy.Application.Common.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using AutoMapper;

namespace Bookeasy.Api.Controllers
{
    [Authorize]
    public class BusinessUsersController : BaseController
    {
        private readonly IMapper _mapper;

        public BusinessUsersController(IMediator mediator, IMapper mapper) : base(mediator)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Get business user's full details
        /// </summary>
        /// <returns>Business user's full details</returns>
        [Route("")]
        [HttpGet]
        [ProducesResponseType(typeof(BusinessUserDetailDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Get()
        {
            try
            {
                var user = await Mediator.Send(new GetBusinessUserQuery(User.GetUserId()));
                return Ok(_mapper.Map<BusinessUserDetailDto>(user));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Create new user
        /// </summary>
        /// <param name="newBusinessUser"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(BusinessUserDetailDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Create(NewBusinessUserDto newBusinessUser)
        {
            try
            {
                var user = await Mediator.Send(new CreateBusinessUserCommand()
                {
                    Email = newBusinessUser.Email,
                    Password = newBusinessUser.Password,
                    FirstName = newBusinessUser.FirstName,
                    LastName = newBusinessUser.LastName,
                    BusinessName = newBusinessUser.BusinessName
                });
                return CreatedAtAction("Get", _mapper.Map<BusinessUserDetailDto>(user));
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
        }
    }
}
