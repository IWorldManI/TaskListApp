using System.Threading.Tasks;
using TaskListApp.Commands.CommentCommands;
using TaskListApp.Database.Models.TaskModels;
using TaskListApp.Queries.CommentQueries;

namespace TaskListApp.Services.CommentService
{
    public interface ICommentService
    {
        Task<Comment> AddCommentAsync(AddCommentCommand command);
        Task<Comment> UpdateCommentAsync(UpdateCommentCommand command);
        Task<Comment> GetCommentByIdAsync(GetCommentByIdQuery query);
        Task<Comment> DeleteCommentAsync(DeleteCommentCommand command);
    }
}
