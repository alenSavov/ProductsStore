using ProductsStore.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace ProductsStore.Models
{
    public class Item 
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(ModelConstants.Item.TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MaxLength(ModelConstants.Item.DescriptionMaxLength)]
        public string Description { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
        

        public string UserId { get; set; }
        public AppUser AppUser { get; set; }


    }
}
