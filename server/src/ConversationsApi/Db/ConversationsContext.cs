using Microsoft.EntityFrameworkCore;
using Workshop.Conversations.Api.Domain.Conversations;
using Workshop.Conversations.Api.Domain.Groups;
using Workshop.Conversations.Api.Domain.Messages;
using Workshop.Conversations.Api.Domain.Threads;

#nullable disable

namespace Workshop.Conversations.Api.Db
{
    public partial class ConversationsContext : DbContext
    {
        public ConversationsContext()
        {
        }

        public ConversationsContext(DbContextOptions<ConversationsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Conversation> Conversations { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Thread> Threads { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.utf8");

            modelBuilder.ApplyConfiguration(new Configurations.ConversationsConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.GroupsConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.MessagesConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.ThreadsConfiguration());
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
