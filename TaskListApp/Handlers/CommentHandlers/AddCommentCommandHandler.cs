using MediatR;
using TaskListApp.Commands.CommentCommands;
using TaskListApp.Services.CommentService;
using TaskListApp.Database.Models.TaskModels;

namespace TaskListApp.Handlers.CommentHandlers
{
    public class AddCommentCommandHandler : IRequestHandler<AddCommentCommand, Comment>
    {
        private readonly ICommentService _commentService;

        public AddCommentCommandHandler(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<Comment> Handle(AddCommentCommand request, CancellationToken cancellationToken)
        {
            return await _commentService.AddCommentAsync(request);
        }
    }
}