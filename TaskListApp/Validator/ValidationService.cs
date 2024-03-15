﻿using FluentValidation.Results;
using TaskListApp.Commands.UserCommands;

namespace TaskListApp.Validator
{
    public class ValidationService : IValidationService
    {
        public ValidationResult ValidateRegisterUser(RegisterUserCommand command)
        {
            var validator = new RegisterUserCommandValidator();
            return validator.Validate(command);
        }
    }
}
