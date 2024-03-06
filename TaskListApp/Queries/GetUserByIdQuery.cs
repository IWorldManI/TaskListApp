using MediatR;
using TaskListApp.Database.Models.User;

namespace TaskListApp.Queries
{
    public class GetUserByIdQuery : IRequest<User>
    {
        public int Id { get; set; }
    }
}