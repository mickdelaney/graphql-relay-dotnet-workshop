using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workshop.ContentApi.Domain
{
    [Table("content_items", Schema = "content")]
    public class ContentItem
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public int ContentTypeId { get; set; }
        
        [Required]
        public ContentType ContentType { get; set; }

        [Required]
        public int OwnerId { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        public string Tag { get; set; }

        public ContentItem() {}
        public ContentItem(int ownerId, string name, string tag)
        {
            OwnerId = ownerId;
            Name = name;
            Tag = tag;
        }
        public ContentItem(int id, int ownerId, string name, string tag)
        {
            Id = id;
            OwnerId = ownerId;
            Name = name;
            Tag = tag;
        }
    }
}