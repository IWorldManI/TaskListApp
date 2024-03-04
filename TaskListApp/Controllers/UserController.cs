using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskListApp.Commands;
using TaskListApp.Models.User;
using TaskListApp.Queries;
using TaskListApp.Services;

namespace TaskListApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserCommand command)
        {
            try
            {
                var user = await _mediator.Send(command);
                return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginQuery query)
        {
            try
            {
                var user = await _mediator.Send(query);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var query = new GetUserByIdQuery { Id = id };
            var user = await _mediator.Send(query);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UpdateUserCommand command)
        {
            try
            {
                command.Id = id;
                var updatedUser = await _mediator.Send(command);
                return Ok(updatedUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var command = new DeleteUserCommand { Id = id };
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
