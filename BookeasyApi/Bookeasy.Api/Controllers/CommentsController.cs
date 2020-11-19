using Bookeasy.Api.DTOs;
using Bookeasy.Application.Comments.Commands.CreateCommentCommand;
using Bookeasy.Application.Comments.Commands.CreateVoteCommentCommand;
using Bookeasy.Application.Comments.Commands.DeleteCommentCommand;
using Bookeasy.Application.Comments.Commands.DeleteVoteCommentCommand;
using Bookeasy.Application.Comments.Commands.UpdateCommentCommand;
using Bookeasy.Application.Common.Enums;
using Bookeasy.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Bookeasy.Api.Controllers
{
    [Authorize]
    [Route("api/posts/{postId}/[controller]")]
    public class CommentsController : BaseController
    {
        private readonly IMediator _mediator;

        public CommentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Add comment to post
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="newComment"></param>
        /// <returns></returns>
        [Route("")]
        [HttpPost]
        [ProducesResponseType(typeof(Comment), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddComment([FromRoute] string postId, NewCommentDto newComment)
        {
            var comment = await _mediator.Send(new CreateCommentCommand()
            {
                OwnerUserId = User.GetUserId(),
                PostId = postId
            });
            return Created("", comment);
        }

        /// <summary>
        /// Update comment
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="commentId"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [Route("{commentId}")]
        [HttpPut]
        [ProducesResponseType(typeof(Comment), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateComment([FromRoute] string postId, [FromRoute] string commentId,
            UpdateCommentCommand command)
        {
            command.CommentId = commentId;
            command.PostId = postId;
            command.OwnerUserId = User.GetUserId();

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        /// <summary>
        /// Delete comment
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="commentId"></param>
        /// <returns></returns>
        [Route("{commentId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete]
        public async Task<IActionResult> DeleteComment([FromRoute] string postId, [FromRoute] string commentId)
        {
            await _mediator.Send(new DeleteCommentCommand { PostId = postId, CommentId = commentId });
            return Ok();
        }

        /// <summary>
        /// Delete vote
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="commentId"></param>
        /// <returns></returns>
        [Route("{commentId}/vote")]
        [HttpDelete]
        public async Task<IActionResult> DeleteVote([FromRoute] string postId, [FromRoute] string commentId)
        {
            await _mediator.Send(new DeleteVoteCommentCommand
            {
                PostId = postId,
                CommentId = commentId,
                UserId = User.GetUserId()
            });

            return Ok();
        }
    }
}
