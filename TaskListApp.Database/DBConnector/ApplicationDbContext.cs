using Microsoft.EntityFrameworkCore;
using TaskListApp.Database.Models.User;

namespace TaskListApp.Database.DBConnector
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
