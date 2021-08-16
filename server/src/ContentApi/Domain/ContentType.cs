using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workshop.ContentApi.Domain
{
    [Table("content_types", Schema = "content")]
    public class ContentType
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public int OwnerId { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        
        public ContentType() {}
        public ContentType(int ownerId, string name)
        {
            OwnerId = ownerId;
            Name = name;
        }
        public ContentType(int id, int ownerId, string name)
        {
            Id = id;
            OwnerId = ownerId;
            Name = name;
        }
    }
}