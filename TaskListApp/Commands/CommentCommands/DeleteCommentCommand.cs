using MediatR;
using TaskListApp.Database.Models.TaskModels;

namespace TaskListApp.Commands.CommentCommands
{
    public class DeleteCommentCommand : IRequest<Comment>
    {
        public int Id { get; set; }
    }
}