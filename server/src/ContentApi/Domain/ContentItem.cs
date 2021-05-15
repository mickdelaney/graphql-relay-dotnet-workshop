using System;
using System.ComponentModel.DataAnnotations;

namespace ContentApi.Domain
{
    public class ContentItem
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public int OwnerId { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Name { get; }

        public ContentItem() {}
        public ContentItem(int id, int ownerId, string name)
        {
            Id = id;
            OwnerId = ownerId;
            Name = name;
        }
    }
}