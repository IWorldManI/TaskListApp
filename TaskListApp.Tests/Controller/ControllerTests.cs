using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TaskListApp.Commands;
using TaskListApp.Controllers;
using TaskListApp.Database.Models.User;
using TaskListApp.Queries;
using Xunit;

namespace TaskListApp.Tests.Controller
{
    public class ControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly UserController _controller;

        public ControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new UserController(_mediatorMock.Object);
        }

        [Fact]
        public async Task Register_ValidCommand_ReturnsCreatedAtAction()
        {
            // Arrange
            // Set up a valid RegisterUserCommand
            var command = new RegisterUserCommand();

            // Mocking the IMediator to return a fake user when the RegisterUserCommand is sent
            _mediatorMock.Setup(x => x.Send(command, default)).ReturnsAsync(new User());

            // Act
            // Calling the Register action of the controller with the valid command
            var result = await _controller.Register(command);

            // Assert
            // Checking if the result is of type CreatedAtActionResult and its action name is "GetUserById"
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal("GetUserById", createdAtActionResult.ActionName);
        }

        [Fact]
        public async Task Login_ValidQuery_ReturnsOkObjectResult()
        {
            // Arrange 
            // Set up a valid LoginQuery
            var query = new LoginQuery();

            // Mocking the IMediator to return a fake user when the LoginQuery is sent
            _mediatorMock.Setup(x => x.Send(query, default)).ReturnsAsync(new User());

            // Act
            // Calling the Login action of the controller with the valid query
            var result = await _controller.Login(query);

            // Assert 
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetUserById_ExistingId_ReturnsOkObjectResult()
        {
            // Arrange 
            // Set up an existing user id for testing
            var testId = 1;

            // Mocking the IMediator to return a fake user when GetUserByIdQuery is sent
            _mediatorMock.Setup(x => x.Send(It.IsAny<GetUserByIdQuery>(), default)).ReturnsAsync(new User());

            // Act
            // Calling the GetUserById action of the controller with the existing user id
            var result = await _controller.GetUserById(testId);

            // Assert 
            Assert.IsType<OkObjectResult>(result);
        }
    }
}