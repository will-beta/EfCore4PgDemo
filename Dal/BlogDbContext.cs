using Microsoft.EntityFrameworkCore;
using Entities;


namespace Dal
{
    public partial class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Post> Posts { get; set; }
    }
}
