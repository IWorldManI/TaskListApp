using MediatR;
using TaskListApp.Database.Models.TaskModels;

namespace TaskListApp.Commands.CommentCommands
{
    public class UpdateCommentCommand : IRequest<Comment>
    {
        public int Id { get; set; } 
        public string NewText { get; set; } 
    }
}