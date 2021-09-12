using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workshop.Conversations.Api.Models;

#nullable disable

namespace Workshop.Conversations.Api.Db.Configurations
{
    public partial class ConversationsConfiguration : IEntityTypeConfiguration<Conversation>
    {
        public void Configure(EntityTypeBuilder<Conversation> entity)
        {
            entity
                .Property(e => e.Id)
                .HasConversion(ConversationId.Converter)
                .ValueGeneratedNever();

            entity
                .Property(e => e.Administration)
                .HasConversion(ConversationAdministration.Converter);
            
            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Conversation> entity);
    }
}
