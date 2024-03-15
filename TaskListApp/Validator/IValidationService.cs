using FluentValidation.Results;
using TaskListApp.Commands.UserCommands;

namespace TaskListApp.Validator
{
    public interface IValidationService
    {
        ValidationResult ValidateRegisterUser(RegisterUserCommand command);
    }
}
