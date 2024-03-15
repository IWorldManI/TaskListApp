using MediatR;
using TaskListApp.Database.Models.TaskModels;
using TaskListApp.Queries.CommentQueries;
using TaskListApp.Services.CommentService;

namespace TaskListApp.Handlers.CommentHandlers
{
    public class GetCommentByIdQueryHandler : IRequestHandler<GetCommentByIdQuery, Comment>
    {
        private readonly ICommentService _commentService;

        public GetCommentByIdQueryHandler(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<Comment> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
            return await _commentService.GetCommentByIdAsync(request);
        }
    }
}