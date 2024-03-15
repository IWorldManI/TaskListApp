using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TaskListApp.Controllers;
using TaskListApp.Commands.CommentCommands;
using TaskListApp.Queries.CommentQueries;
using Xunit;
using TaskListApp.Database.Models.TaskModels;

namespace TaskListApp.Tests.Controller
{
    public class CommentControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly CommentController _controller;

        public CommentControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new CommentController(_mediatorMock.Object);
        }

        /// <summary>
        /// Tests the AddComment method of the CommentController controller.
        /// </summary>
        [Fact]
        public async Task AddComment_ValidCommand_ReturnsCreatedAtAction()
        {
            var command = new AddCommentCommand();
            _mediatorMock.Setup(x => x.Send(command, default)).ReturnsAsync(new Comment());

            var result = await _controller.AddComment(command);

            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal("GetCommentById", createdAtActionResult.ActionName);
        }

        /// <summary>
        /// Tests the GetCommentById method of the CommentController controller.
        /// </summary>
        [Fact]
        public async Task GetCommentById_ExistingId_ReturnsOkObjectResult()
        {
            var testId = 1;
            _mediatorMock.Setup(x => x.Send(It.IsAny<GetCommentByIdQuery>(), default)).ReturnsAsync(new Comment());

            var result = await _controller.GetCommentById(testId);

            Assert.IsType<OkObjectResult>(result);
        }

        /// <summary>
        /// Tests the UpdateComment method of the CommentController controller.
        /// </summary>
        [Fact]
        public async Task UpdateComment_ValidCommand_ReturnsOkObjectResult()
        {
            var testId = 1;
            var command = new UpdateCommentCommand();
            _mediatorMock.Setup(x => x.Send(command, default)).ReturnsAsync(new Comment());

            var result = await _controller.UpdateComment(testId, command);

            Assert.IsType<OkObjectResult>(result);
        }

        /// <summary>
        /// Tests the DeleteComment method of the CommentController controller.
        /// </summary>
        [Fact]
        public async Task DeleteComment_ExistingId_ReturnsNoContentResult()
        {
            var testId = 1;

            var result = await _controller.DeleteComment(testId);

            Assert.IsType<NoContentResult>(result);
        }
    }
}