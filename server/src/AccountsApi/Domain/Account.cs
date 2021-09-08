using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workshop.AccountsApi.Domain
{
    [Table("account", Schema = "accounts")]
    public class Account
    {
        [Required]
        [Key]
        [Column("id")]
        public AccountId Id { get; set; }
         
        [Required]
        [StringLength(200)]
        [Column("first_name")]
        public string FirstName { get; set;  }
        
        [Required]
        [StringLength(200)]
        [Column("last_name")]
        public string LastName { get; set;  }

        public Account()
        {
        }

        public Account(AccountId id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
    }
    
}