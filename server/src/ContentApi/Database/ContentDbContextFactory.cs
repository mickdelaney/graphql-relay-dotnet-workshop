using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Workshop.Core.Config;

namespace Workshop.ContentApi.Database
{
    public class ContentDbContextFactory : IDesignTimeDbContextFactory<ContentDbContext>
    {
        public ContentDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ContentDbContext>();
            
            optionsBuilder.UseNpgsql
                (
                    x =>
                    {
                        x.MigrationsAssembly(typeof(ContentDbContext).Assembly.FullName);
                        x.MigrationsHistoryTable(WorkshopConfig.EfMigrationsTable, WorkshopConfig.ContentSchemaName);
                    }
                )
                .UseSnakeCaseNamingConvention();
            
            return new ContentDbContext(optionsBuilder.Options);
        }
    }
}