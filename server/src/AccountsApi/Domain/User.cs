using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workshop.Accounts.Api.Domain
{
    [Table("users", Schema = "accounts")]
    public class User
    {
        [Required]
        [Key]
        [Column("id")]
        public UserId Id { get; set; }
         
        [Required]
        [StringLength(200)]
        [Column("name")]
        public string Name { get; set;  }
        
        [StringLength(1000)]
        [Column("web_site")]
        public virtual string? WebSite { get; set; }

        public User() {}
        public User(UserId id, string name, string? webSite)
        {
            Id = id;
            Name = name;
            WebSite = webSite;
        }
    }
    
}