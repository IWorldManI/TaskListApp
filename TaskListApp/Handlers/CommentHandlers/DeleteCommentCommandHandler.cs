using MediatR;
using TaskListApp.Commands.CommentCommands;
using TaskListApp.Services.CommentService;
using TaskListApp.Database.Models.TaskModels;

namespace TaskListApp.Handlers.CommentHandlers
{
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, Comment>
    {
        private readonly ICommentService _commentService;

        public DeleteCommentCommandHandler(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<Comment> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            return await _commentService.DeleteCommentAsync(request);
        }
    }
}