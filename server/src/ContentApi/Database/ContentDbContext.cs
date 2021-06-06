using Microsoft.EntityFrameworkCore;
using Workshop.ContentApi.Domain;

namespace Workshop.ContentApi.Database
{
    public class ContentDbContext : DbContext
    {
        public ContentDbContext
        (
            DbContextOptions<ContentDbContext> options
        )
        : base(options)
        {
        }

        public DbSet<ContentType> ContentTypes { get; set; } = default!;
        public DbSet<ContentItem> ContentItems { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var contentType = modelBuilder.Entity<ContentType>();
            contentType.HasKey(c => c.Id);
            
            var contentItem = modelBuilder.Entity<ContentItem>();
            
            contentItem.HasKey(c => c.Id);
            contentItem.HasOne(p => p.ContentType);
        }
    }
}