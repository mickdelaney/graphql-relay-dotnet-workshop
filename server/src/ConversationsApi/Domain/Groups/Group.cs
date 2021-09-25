using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using NodaTime;

namespace Workshop.Conversations.Api.Domain.Groups
{
    [Table("groups", Schema = "conversations")]
    [Index(nameof(AccountId), Name = "groups_account_id_idx")]
    [Index(nameof(CreatedById), Name = "groups_created_by_id_idx")]
    [Index(nameof(CreatedOn), Name = "groups_created_on_idx")]
    [Index(nameof(Name), Name = "groups_name_idx")]
    public partial class Group
    {
        [Key]
        [Column("id")]
        public GroupId Id { get; set; }
        [Required]
        [Column("name")]
        public string Name { get; set; } = default!;
        [Column("description")]
        public string? Description { get; set; }
        [Column("created_on", TypeName = "timestamp with time zone")]
        public Instant CreatedOn { get; set; }
        [Column("created_by_id")]
        public Guid CreatedById { get; set; }
        [Column("updated_on", TypeName = "timestamp with time zone")]
        public Instant UpdatedOn { get; set; }
        [Column("updated_by_id")]
        public Guid UpdatedById { get; set; }
        [Column("account_id")]
        public Guid AccountId { get; set; }
    }
}