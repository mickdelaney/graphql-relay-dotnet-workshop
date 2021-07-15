using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Workshop.ContentApi.Database;
using Workshop.Core.Config;

namespace Workshop.ContentApi.Migrations
{
    public class ContentDbContextFactory : IDesignTimeDbContextFactory<ContentDbContext>
    {
        public ContentDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ContentDbContext>();
            
            optionsBuilder.UseNpgsql
                (
                    WorkshopConfig.PostgresConnectionString,
                    x => x.MigrationsAssembly(typeof(ContentDbContextFactory).Assembly.FullName)
                )
                .UseSnakeCaseNamingConvention();
            
            return new ContentDbContext(optionsBuilder.Options);
        }
    }
}