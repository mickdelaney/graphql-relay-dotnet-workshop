using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workshop.Conversations.Api.Models;

#nullable disable

namespace Workshop.Conversations.Api.Db.Configurations
{
    public partial class ThreadsConfiguration : IEntityTypeConfiguration<Thread>
    {
        public void Configure(EntityTypeBuilder<Thread> entity)
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Conversation)
                .WithMany(p => p.Threads)
                .HasForeignKey(d => d.ConversationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("threads_fk");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Thread> entity);
    }
}
