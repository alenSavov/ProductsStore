using ProductsStore.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductsStore.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(ModelConstants.Category.NameMaxLength)]
        public string Name { get; set; }

        public ICollection<SubCategory> SubCategories { get; set; }
    }
}
