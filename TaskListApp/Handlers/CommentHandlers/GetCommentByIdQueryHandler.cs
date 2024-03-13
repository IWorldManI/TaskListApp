using MediatR;
using TaskListApp.Database.Models.TaskModels;
using TaskListApp.Queries.CommentQueries;
using TaskListApp.Services.AuthentificationService;
using TaskListApp.Services.CommentService;

namespace TaskListApp.Handlers.CommentHandlers
{
    public class GetCommentByIdQueryHandler : IRequestHandler<GetCommentByIdQuery, Comment>
    {
        private readonly ICommentService _commentService;
        private readonly AuthenticationService _authenticationService;

        public GetCommentByIdQueryHandler(ICommentService commentService, AuthenticationService authenticationService)
        {
            _commentService = commentService;
            _authenticationService = authenticationService;
        }

        public async Task<Comment> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
            _authenticationService.EnsureTokenIsValid();

            return await _commentService.GetCommentByIdAsync(request);
        }
    }
}