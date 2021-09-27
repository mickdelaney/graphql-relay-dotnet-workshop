using System;
using Microsoft.EntityFrameworkCore;
using Workshop.Accounts.Api.Domain;

namespace Workshop.Accounts.Api.Database
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

        public DbSet<User> People { get; set; } = default!;
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<User>()
                .HasKey(c => c.Id);
            
            modelBuilder
                .Entity<User>()
                .Property(c => c.Id)
                .HasConversion(x => MapId(x), x => CreateId(x));
        }
        
        static UserId CreateId(Guid x)
        {
            return new UserId(x);
        }

        static Guid MapId(UserId x)
        {
            return x.Value;
        }
    }
}