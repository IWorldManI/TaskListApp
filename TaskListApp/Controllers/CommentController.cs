using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskListApp.Commands.CommentCommands;
using TaskListApp.Queries.CommentQueries;

namespace TaskListApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [CustomAuthorize]
        [HttpPost]
        public async Task<IActionResult> AddComment(AddCommentCommand command)
        {
            try
            {
                var comment = await _mediator.Send(command);
                return CreatedAtAction(nameof(GetCommentById), new { id = comment.Id }, comment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [CustomAuthorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommentById(int id)
        {
            var query = new GetCommentByIdQuery { Id = id };
            var comment = await _mediator.Send(query);

            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment);
        }

        [CustomAuthorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComment(int id, UpdateCommentCommand command)
        {
            try
            {
                command.Id = id;
                var updatedComment = await _mediator.Send(command);
                return Ok(updatedComment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [CustomAuthorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            try
            {
                var command = new DeleteCommentCommand { Id = id };
                await _mediator.Send(command);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
