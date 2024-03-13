using TaskListApp.Commands.CommentCommands;
using TaskListApp.Database.DBConnector;
using TaskListApp.Database.Models.TaskModels;
using TaskListApp.Queries.CommentQueries;

namespace TaskListApp.Services.CommentService
{
    public class CommentService : ICommentService
    {
        private readonly ApplicationDbContext _context;
        public CommentService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Comment> AddCommentAsync(AddCommentCommand command)
        {
            try
            {
                var task = await _context.TaskItems.FindAsync(command.TaskId);

                if (task == null)
                {
                    throw new Exception("Task not found");
                }

                var comment = new Comment
                {
                    Text = command.Text,
                    CreatedDate = DateTime.UtcNow,
                    TaskItemId = command.TaskId
                };

                _context.Comments.Add(comment);
                await _context.SaveChangesAsync();

                return comment;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the comment.", ex);
            }
        }

        public async Task<Comment> UpdateCommentAsync(UpdateCommentCommand command)
        {
            try
            {
                var comment = await _context.Comments.FindAsync(command.Id);

                if (comment == null)
                {
                    throw new Exception("Comment not found");
                }

                comment.Text = command.NewText;

                await _context.SaveChangesAsync();

                return comment;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the comment.", ex);
            }
        }

        public async Task<Comment> DeleteCommentAsync(DeleteCommentCommand command)
        {
            try
            {
                var comment = await _context.Comments.FindAsync(command.Id);

                if (comment == null)
                {
                    throw new Exception("Comment not found");
                }

                _context.Comments.Remove(comment);
                await _context.SaveChangesAsync();

                return comment;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the comment.", ex);
            }
        }

        public async Task<Comment> GetCommentByIdAsync(GetCommentByIdQuery query)
        {
            var comment = await _context.Comments.FindAsync(query.Id);

            if (comment == null)
            {
                throw new Exception("Comment not found");
            }

            return comment;
        }
    }
}