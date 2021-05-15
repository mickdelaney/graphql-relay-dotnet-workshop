using System.ComponentModel.DataAnnotations;

namespace NextGen.AccountsApi.Domain
{
    public class Person
    {
        [Required]
        public int Id { get; set; }
         
        [Required]
        [StringLength(200)]
        public string Name { get; set;  }
        
        [StringLength(1000)]
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