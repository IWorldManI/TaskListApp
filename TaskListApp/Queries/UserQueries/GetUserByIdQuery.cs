using MediatR;
using TaskListApp.Database.Models.UserModel;

namespace TaskListApp.Queries.UserQueries
{
    public class GetUserByIdQuery : IRequest<User>
    {
        public int Id { get; set; }
    }
}