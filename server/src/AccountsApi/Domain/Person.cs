using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workshop.Accounts.Api.Domain
{
    [Table("people", Schema = "accounts")]
    public class Person
    {
        [Required]
        [Key]
        [Column("id")]
        public PersonId Id { get; set; }
         
        [Required]
        [StringLength(200)]
        [Column("name")]
        public string Name { get; set;  }
        
        [StringLength(1000)]
        [Column("web_site")]
        public virtual string? WebSite { get; set; }

        public Person() {}
        public Person(PersonId id, string name, string? webSite)
        {
            Id = id;
            Name = name;
            WebSite = webSite;
        }
    }
    
}