using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.Json.Serialization;
using TaskListApp.Database.Models.UserModel;

namespace TaskListApp.Commands.UserCommands
{
    public class UpdateUserCommand : IRequest<User>
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
