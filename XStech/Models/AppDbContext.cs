using Microsoft.EntityFrameworkCore;

namespace XStech.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :
            base(options)
        {

        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Commenter> Commenters { get; set; }
        public DbSet<Post> Posts { get; set; }

    }
}
