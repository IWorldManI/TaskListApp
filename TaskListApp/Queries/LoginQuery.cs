﻿using MediatR;
using TaskListApp.Models.User;

namespace TaskListApp.Queries
{
    public class LoginQuery : IRequest<User>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}