using MediatR;
using TaskListApp.Models.User;

namespace TaskListApp.Queries
{
    public class GetUsersQuery : IRequest<IEnumerable<User>>
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string Name { get; set; }
        public string SortBy { get; set; }
        public string SortDirection { get; set; }
    }
}
