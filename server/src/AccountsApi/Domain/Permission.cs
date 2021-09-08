using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workshop.AccountsApi.Domain
{
    [Table("permissions", Schema = "accounts")]
    public class Permission
    {
        [Required]
        [Key]
        [Column("id")]
        public int Id { get; set; }
         
        [Required]
        [StringLength(200)]
        [Column("name")]
        public string Name { get; set;  }

        public Permission() {}
        public Permission(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}