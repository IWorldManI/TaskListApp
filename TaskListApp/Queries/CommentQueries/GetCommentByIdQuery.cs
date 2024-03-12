using MediatR;
using TaskListApp.Database.Models.TaskModels;

namespace TaskListApp.Queries.CommentQueries
{
    public class GetCommentByIdQuery : IRequest<Comment>
    {
        public int Id { get; set; }
    }
}