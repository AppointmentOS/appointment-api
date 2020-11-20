using AutoMapper;
using Bookeasy.Api.DTOs;
using Bookeasy.Application.Users.Queries.GetAuthenticationToken;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace Bookeasy.Api.Controllers
{
    using MediatR;

    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : BaseController
    {
        private IConfiguration _config;
        private readonly IMapper _mapper;

        public LoginController(IMediator mediator, IConfiguration config, IMapper mapper) : base(mediator)
        {
            _config = config;
            _mapper = mapper;
        }

        // GET
        /// <summary>
        /// Get authentication token
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login([FromBody] GetAuthenticationTokenQuery query)
        {
            var result = await Mediator.Send(query);
            if (!result.Failed)
                return Ok(result.Payload);

            return BadRequest(new ProblemDetails() { Title = result.Error.Message });
        }
    }
}
