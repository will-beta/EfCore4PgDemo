using Microsoft.EntityFrameworkCore;
using Entities;


namespace Dal.Pg
{
    public class PgBlogDbContext : BlogDbContext
    {
        public PgBlogDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region 数据类型映射

            modelBuilder.Entity<Post>().Property(e => e.Author).HasColumnType("json");

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
