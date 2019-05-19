using ProductsStore.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductsStore.Models
{
    public class SubCategory
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(ModelConstants.SubCategory.NameMaxLength)]
        public string Name { get; set; }

        public string CategoryId { get; set; }

        public Category Category { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}
