using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using NodaTime;

namespace Workshop.Conversations.Api.Models
{
    [Table("messages", Schema = "conversations")]
    [Index(nameof(AccountId), Name = "messages_account_id_idx")]
    [Index(nameof(CreatedById), Name = "messages_created_by_id_idx")]
    [Index(nameof(CreatedOn), Name = "messages_created_on_idx")]
    [Index(nameof(Title), Name = "messages_title_idx")]
    public partial class Message
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        [Column("conversation_id")]
        public Guid ConversationId { get; set; }
        [Column("thread_id")]
        public Guid ThreadId { get; set; }
        [Required]
        [Column("title")]
        public string Title { get; set; } = default!;
        [Column("description")]
        public string? Description { get; set; }
        [Required]
        [Column("content_items", TypeName = "jsonb")]
        public string ContentItems { get; set; } = default!;
        [Required]
        [Column("reactions", TypeName = "jsonb")]
        public string Reactions { get; set; } = default!;
        [Column("is_pinned")]
        public bool IsPinned { get; set; }
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

        [ForeignKey(nameof(ConversationId))]
        [InverseProperty(nameof(Models.Conversation.Messages))]
        public virtual Conversation Conversation { get; set; } = default!;
        [ForeignKey(nameof(ThreadId))]
        [InverseProperty(nameof(Models.Thread.Messages))]
        public virtual Thread Thread { get; set; } = default!;
    }
}