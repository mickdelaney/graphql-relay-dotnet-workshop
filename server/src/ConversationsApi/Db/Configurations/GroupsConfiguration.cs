using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workshop.Conversations.Api.Models;

#nullable disable

namespace Workshop.Conversations.Api.Db.Configurations
{
    public partial class GroupsConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> entity)
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Group> entity);
    }
}
