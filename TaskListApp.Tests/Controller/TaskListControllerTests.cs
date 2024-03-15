using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TaskListApp.Controllers;
using TaskListApp.Commands.TaskListCommands;
using TaskListApp.Queries.TaskListQueries;
using Xunit;
using TaskListApp.Database.Models.TaskListModel;

namespace TaskListApp.Tests.Controller
{
    public class TaskListControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly TaskListController _controller;

        public TaskListControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new TaskListController(_mediatorMock.Object);
        }

        /// <summary>
        /// Tests the CreateTaskList method of the TaskListController controller.
        /// </summary>
        [Fact]
        public async Task CreateTaskList_ValidCommand_ReturnsCreatedAtAction()
        {
            var command = new CreateTaskListCommand();
            _mediatorMock.Setup(x => x.Send(command, default)).ReturnsAsync(new TaskList());

            var result = await _controller.CreateTaskList(command);

            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal("GetTaskListById", createdAtActionResult.ActionName);
        }

        /// <summary>
        /// Tests the GetTaskListById method of the TaskListController controller.
        /// </summary>
        [Fact]
        public async Task GetTaskListById_ExistingId_ReturnsOkObjectResult()
        {
            var testId = 1;
            _mediatorMock.Setup(x => x.Send(It.IsAny<GetTaskListByIdQuery>(), default)).ReturnsAsync(new TaskList());

            var result = await _controller.GetTaskListById(testId);

            Assert.IsType<OkObjectResult>(result);
        }

        /// <summary>
        /// Tests the UpdateTaskList method of the TaskListController controller.
        /// </summary>
        [Fact]
        public async Task UpdateTaskList_ValidCommand_ReturnsOkObjectResult()
        {
            var testId = 1;
            var command = new UpdateTaskListCommand();
            _mediatorMock.Setup(x => x.Send(command, default)).ReturnsAsync(new TaskList());

            var result = await _controller.UpdateTaskList(testId, command);

            Assert.IsType<OkObjectResult>(result);
        }

        /// <summary>
        /// Tests the MoveTasksToAnotherList method of the TaskListController controller.
        /// </summary>
        [Fact]
        public async Task MoveTasksToAnotherList_ValidCommand_ReturnsOkObjectResult()
        {
            var command = new MoveTasksToAnotherListCommand();
            _mediatorMock.Setup(x => x.Send(command, default)).ReturnsAsync(new TaskList());

            var result = await _controller.MoveTasksToAnotherList(command);

            Assert.IsType<OkObjectResult>(result);
        }

        /// <summary>
        /// Tests the DeleteTaskList method of the TaskListController controller.
        /// </summary>
        [Fact]
        public async Task DeleteTaskList_ExistingId_ReturnsNoContentResult()
        {
            var testId = 1;

            var result = await _controller.DeleteTaskList(testId);

            Assert.IsType<NoContentResult>(result);
        }

        /// <summary>
        /// Tests the DeleteNonEmptyList method of the TaskListController controller.
        /// </summary>
        [Fact]
        public async Task DeleteNonEmptyList_ValidCommand_ReturnsNoContentResult()
        {
            var command = new DeleteNonEmptyListCommand();

            var result = await _controller.DeleteNonEmptyList(command);

            Assert.IsType<NoContentResult>(result);
        }
    }
}
