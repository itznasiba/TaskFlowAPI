using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YoutubeAPI.Core.User;
using YoutubeAPI.Core.Product;

namespace YoutubeAPI.DataAccess.Repository
{
    public class YoutubeDbContext : DbContext
    {
        public YoutubeDbContext(DbContextOptions<YoutubeDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
            });
        }
    }
}
