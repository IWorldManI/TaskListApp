using FluentValidation.Results;
using TaskListApp.Commands.UserCommands;

namespace TaskListApp.Services.ValidationService
{
    public interface IValidationService
    {
        ValidationResult ValidateRegisterUser(RegisterUserCommand command);
    }
}
