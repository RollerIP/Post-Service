using Microsoft.EntityFrameworkCore;
using Post_Service.Models;

namespace Post_Service.Contexts
{
    public class PostContext : DbContext
    {
        public PostContext(DbContextOptions<PostContext> options)
            : base(options) { }

        // Entities        
        public DbSet<Post> Posts { get; set; }
    }
}
