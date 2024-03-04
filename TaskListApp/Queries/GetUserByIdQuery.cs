using MediatR;
using TaskListApp.Models.User;

namespace TaskListApp.Queries
{
    public class GetUserByIdQuery : IRequest<User>
    {
        public int Id { get; set; }
    }
}