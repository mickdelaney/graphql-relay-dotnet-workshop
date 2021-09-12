using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using NodaTime;
using Workshop.Core.Domain;

namespace Workshop.Conversations.Api.Models
{
    [Table("conversations", Schema = "conversations")]
    [Index(nameof(AccountId), Name = "conversations_account_id_idx")]
    [Index(nameof(CreatedById), Name = "conversations_created_by_id_idx")]
    [Index(nameof(CreatedOn), Name = "conversations_created_on_idx")]
    [Index(nameof(Title), Name = "conversations_title_idx")]
    public partial class Conversation : IAuditableEntity
    {
        public Conversation()
        {
            Messages = new HashSet<Message>();
            Threads = new HashSet<Thread>();
        }

        [Key]
        [Column("id")]
        public ConversationId Id { get; set; }
        
        [Required]
        [Column("title")]
        public string Title { get; set; } = default!;
        
        [Column("description")]
        public string? Description { get; set; }
        
        [Column("created_on", TypeName = "timestamp with time zone")]
        public Instant CreatedOn { get; set; }
        
        [Column("created_by_id")]
        public UserId CreatedById { get; set; }

        [Column("updated_on", TypeName = "timestamp with time zone")]
        public Instant UpdatedOn { get; set; }
        
        [Column("updated_by_id")]
        public UserId UpdatedById { get; set; }

        [Column("account_id")]
        public AccountId AccountId { get; set; }
        
        [Required]
        [Column("administration", TypeName = "jsonb")]
        public ConversationAdministration Administration { get; set; } = new();

        [InverseProperty("Conversation")]
        public virtual ICollection<Message> Messages { get; set; }
        
        [InverseProperty("Conversation")]
        public virtual ICollection<Thread> Threads { get; set; }
    }
}