using Microsoft.EntityFrameworkCore;
using Post_Service.Models;

namespace Post_Service.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options) { }

        // Entities        
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
