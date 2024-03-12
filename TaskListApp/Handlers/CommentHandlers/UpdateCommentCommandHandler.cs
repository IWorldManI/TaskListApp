using MediatR;
using TaskListApp.Commands.CommentCommands;
using TaskListApp.Services.CommentService;
using TaskListApp.Database.Models.TaskModels;

namespace TaskListApp.Handlers.CommentHandlers
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, Comment>
    {
        private readonly ICommentService _commentService;

        public UpdateCommentCommandHandler(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<Comment> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            return await _commentService.UpdateCommentAsync(request);
        }
    }
}