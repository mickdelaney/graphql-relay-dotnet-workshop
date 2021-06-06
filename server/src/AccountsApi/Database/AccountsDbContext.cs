using Microsoft.EntityFrameworkCore;
using Workshop.AccountsApi.Domain;

namespace Workshop.AccountsApi.Database
{
    public class AccountsDbContext : DbContext
    {
        public AccountsDbContext
        (
            DbContextOptions<AccountsDbContext> options
        )
        : base(options)
        {
        }

        public DbSet<Person> People { get; set; } = default!;
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>().HasKey(c => c.Id);
        }
    }
}