using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TaskListApp.Controllers;
using TaskListApp.Commands.TaskCommands;
using TaskListApp.Queries.TaskQueries;
using TaskListApp.Database.Models.TaskModels;
using Xunit;

namespace TaskListApp.Tests.Controller
{
    public class TaskControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly TaskController _controller;

        public TaskControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new TaskController(_mediatorMock.Object);
        }

        /// <summary>
        /// Tests the CreateTask method of the TaskController controller.
        /// </summary>
        [Fact]
        public async Task CreateTask_ValidCommand_ReturnsCreatedAtAction()
        {
            var command = new CreateTaskCommand();
            _mediatorMock.Setup(x => x.Send(command, default)).ReturnsAsync(new TaskItem());

            var result = await _controller.CreateTask(command);

            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal("GetTaskById", createdAtActionResult.ActionName);
        }

        /// <summary>
        /// Tests the GetTaskById method of the TaskController controller.
        /// </summary>
        [Fact]
        public async Task GetTaskById_ExistingId_ReturnsOkObjectResult()
        {
            var testId = 1;
            _mediatorMock.Setup(x => x.Send(It.IsAny<GetTaskByIdQuery>(), default)).ReturnsAsync(new TaskItem());

            var result = await _controller.GetTaskById(testId);

            Assert.IsType<OkObjectResult>(result);
        }

        /// <summary>
        /// Tests the UpdateTask method of the TaskController controller.
        /// </summary>
        [Fact]
        public async Task UpdateTask_ValidCommand_ReturnsOkObjectResult()
        {
            var testId = 1;
            var command = new UpdateTaskCommand();
            _mediatorMock.Setup(x => x.Send(command, default)).ReturnsAsync(new TaskItem());

            var result = await _controller.UpdateTask(testId, command);

            Assert.IsType<OkObjectResult>(result);
        }

        /// <summary>
        /// Tests the DeleteTask method of the TaskController controller.
        /// </summary>
        [Fact]
        public async Task DeleteTask_ExistingId_ReturnsNoContentResult()
        {
            var testId = 1;

            var result = await _controller.DeleteTask(testId);

            Assert.IsType<NoContentResult>(result);
        }
    }
}