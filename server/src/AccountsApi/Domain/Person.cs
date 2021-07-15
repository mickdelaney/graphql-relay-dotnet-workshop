using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workshop.AccountsApi.Domain
{
    [Table("people")]
    public class Person
    {
        [Required]
        [Key]
        [Column("id")]
        public int Id { get; set; }
         
        [Required]
        [StringLength(200)]
        [Column("name")]
        public string Name { get; set;  }
        
        [StringLength(1000)]
        [Column("web_site")]
        public virtual string? WebSite { get; set; }

        public Person() {}
        public Person(int id, string name, string? webSite)
        {
            Id = id;
            Name = name;
            WebSite = webSite;
        }
    }
    
}