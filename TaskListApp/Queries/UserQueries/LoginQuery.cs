using MediatR;
using TaskListApp.Database.Models.UserModel;

namespace TaskListApp.Queries.UserQueries
{
    public class LoginQuery : IRequest<User>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}