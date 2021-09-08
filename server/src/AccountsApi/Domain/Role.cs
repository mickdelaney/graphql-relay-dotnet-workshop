using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workshop.AccountsApi.Domain
{
    [Table("roles", Schema = "accounts")]
    public class Role
    {
        [Required]
        [Key]
        [Column("id")]
        public int Id { get; set; }
         
        [Required]
        [StringLength(200)]
        [Column("name")]
        public string Name { get; set;  }

        public Role() {}
        public Role(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}