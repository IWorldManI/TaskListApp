using MediatR;
using TaskListApp.Database.Models.TaskModels;

namespace TaskListApp.Commands.CommentCommands
{
    public class AddCommentCommand : IRequest<Comment>
    {
        public int TaskId { get; set; }
        public string Text { get; set; }
    }
}
