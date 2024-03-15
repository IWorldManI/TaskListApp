using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TaskListApp.Controllers;
using TaskListApp.Database.Models.UserModel;
using TaskListApp.Commands.UserCommands;
using TaskListApp.Queries.UserQueries;
using Xunit;

namespace TaskListApp.Tests.Controller
{
    public class UserControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly UserController _controller;

        public UserControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new UserController(_mediatorMock.Object);
        }

        /// <summary>
        /// Tests the Register method of the UserController controller.
        /// </summary>
        [Fact]
        public async Task Register_ValidCommand_ReturnsCreatedAtAction()
        {
            var command = new RegisterUserCommand();
            _mediatorMock.Setup(x => x.Send(command, default)).ReturnsAsync(new User());

            var result = await _controller.Register(command);

            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal("GetUserById", createdAtActionResult.ActionName);
        }

        /// <summary>
        /// Tests the Login method of the UserController controller.
        /// </summary>
        [Fact]
        public async Task Login_ValidQuery_ReturnsOkObjectResult()
        {
            var query = new LoginQuery();
            _mediatorMock.Setup(x => x.Send(query, default)).ReturnsAsync(new User());

            var result = await _controller.Login(query);

            Assert.IsType<OkObjectResult>(result);
        }

        /// <summary>
        /// Tests the GetUserById method of the UserController controller.
        /// </summary>
        [Fact]
        public async Task GetUserById_ExistingId_ReturnsOkObjectResult()
        {
            var testId = 1;
            _mediatorMock.Setup(x => x.Send(It.IsAny<GetUserByIdQuery>(), default)).ReturnsAsync(new User());

            var result = await _controller.GetUserById(testId);
 
            Assert.IsType<OkObjectResult>(result);
        }

        /// <summary>
        /// Tests the DeleteUser method of the UserController controller when an existing user ID is provided.
        /// Ensures that a NoContentResult is returned indicating successful deletion.
        /// </summary>
        [Fact]
        public async Task DeleteUser_ExistingId_ReturnsNoContentResult()
        {
            var testId = 1;

            var result = await _controller.DeleteUser(testId);

            Assert.IsType<NoContentResult>(result);
        }
    }
}