using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workshop.Conversations.Api.Domain.Messages;

#nullable disable

namespace Workshop.Conversations.Api.Db.Configurations
{
    public partial class MessagesConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> entity)
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Conversation)
                .WithMany(p => p.Messages)
                .HasForeignKey(d => d.ConversationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("messages_conversation_fk");

            entity.HasOne(d => d.Thread)
                .WithMany(p => p.Messages)
                .HasForeignKey(d => d.ThreadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("messages_thread_fk");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Message> entity);
    }
}
