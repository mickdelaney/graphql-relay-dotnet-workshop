using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using NodaTime;
using Workshop.Conversations.Api.Domain.Conversations;
using Workshop.Conversations.Api.Domain.Messages;

namespace Workshop.Conversations.Api.Domain.Threads
{
    [Table("threads", Schema = "conversations")]
    [Index(nameof(AccountId), Name = "threads_account_id_idx")]
    [Index(nameof(CreatedById), Name = "threads_created_by_id_idx")]
    [Index(nameof(CreatedOn), Name = "threads_created_on_idx")]
    [Index(nameof(Name), Name = "threads_name_idx")]
    public partial class Thread
    {
        public Thread()
        {
            Messages = new HashSet<Message>();
        }

        [Key]
        [Column("id")]
        public ThreadId Id { get; set; }
        [Column("conversation_id")]
        public Guid ConversationId { get; set; }
        [Required]
        [Column("name")]
        public string Name { get; set; } = default!;
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
        [InverseProperty(nameof(Conversations.Conversation.Threads))]
        public virtual Conversation Conversation { get; set; } = default!;
        [InverseProperty("Thread")]
        public virtual ICollection<Message> Messages { get; set; }
    }
}