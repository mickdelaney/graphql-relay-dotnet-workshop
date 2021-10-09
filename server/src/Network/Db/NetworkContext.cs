using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Workshop.Network.Api.Db
{
    public partial class NetworkContext : DbContext
    {
        public NetworkContext(DbContextOptions<NetworkContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.utf8");
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
