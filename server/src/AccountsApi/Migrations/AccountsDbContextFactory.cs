using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Workshop.AccountsApi.Database;
using Workshop.Core.Config;

namespace Workshop.AccountsApi.Migrations
{
    public class AccountsDbContextFactory : IDesignTimeDbContextFactory<AccountsDbContext>
    {
        public AccountsDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AccountsDbContext>();
            
            optionsBuilder.UseNpgsql
                (
                    WorkshopConfig.PostgresConnectionString,
                    x => x.MigrationsAssembly(typeof(AccountsDbContextFactory).Assembly.FullName)
                )
                .UseSnakeCaseNamingConvention();
            
            return new AccountsDbContext(optionsBuilder.Options);
        }
    }
}