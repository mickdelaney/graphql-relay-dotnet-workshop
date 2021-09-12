using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Workshop.Core.Config;

namespace Workshop.Accounts.Api.Database
{
    public class AccountsDbContextFactory : IDesignTimeDbContextFactory<AccountsDbContext>
    {
        public AccountsDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AccountsDbContext>();
            
            optionsBuilder.UseNpgsql
                (
                    x =>
                    {
                        x.MigrationsAssembly(typeof(AccountsDbContext).Assembly.FullName);
                        x.MigrationsHistoryTable(WorkshopConfig.EfMigrationsTable, WorkshopConfig.AccountsSchemaName);
                    }
                )
                .UseSnakeCaseNamingConvention();
            
            return new AccountsDbContext(optionsBuilder.Options);
        }
    }
}