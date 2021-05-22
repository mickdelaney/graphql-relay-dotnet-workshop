using Microsoft.EntityFrameworkCore;
using NextGen.AccountsApi.Domain;

namespace NextGen.AccountsApi.Database
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