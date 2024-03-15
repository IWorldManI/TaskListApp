using MediatR;
using TaskListApp.Commands.TaskListCommands;
using TaskListApp.Queries.TaskListQueries;
using Microsoft.AspNetCore.Mvc;
namespace TaskListApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskListController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaskListController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [CustomAuthorize]
        [HttpPost]
        public async Task<IActionResult> CreateTaskList(CreateTaskListCommand command)
        {
            try
            {
                var taskList = await _mediator.Send(command);
                return CreatedAtAction(nameof(GetTaskListById), new { id = taskList.Id }, taskList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [CustomAuthorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskListById(int id)
        {
            var query = new GetTaskListByIdQuery { Id = id };
            var taskList = await _mediator.Send(query);

            if (taskList == null)
            {
                return NotFound();
            }

            return Ok(taskList);
        }

        [CustomAuthorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTaskList(int id, UpdateTaskListCommand command)
        {
            try
            {
                command.Id = id;
                var updatedTaskList = await _mediator.Send(command);
                return Ok(updatedTaskList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [CustomAuthorize]
        [HttpPut("sourceListId/move-tasks-to/targetListId")]
        public async Task<IActionResult> MoveTasksToAnotherList(MoveTasksToAnotherListCommand command)
        {
            try
            {
                var targetListContent = await _mediator.Send(command);
                return Ok(targetListContent);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [CustomAuthorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskList(int id)
        {
            try
            {
                var command = new DeleteTaskListCommand { Id = id };
                await _mediator.Send(command);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [CustomAuthorize]
        [HttpDelete("sourceListId/move-to/targetListId")]
        public async Task<IActionResult> DeleteNonEmptyList(DeleteNonEmptyListCommand command)
        {
            try
            {
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