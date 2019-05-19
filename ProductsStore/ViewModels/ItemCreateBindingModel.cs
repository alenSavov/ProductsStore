using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProductsStore.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductsStore.ViewModels
{
    public class ItemCreateBindingModel
    {
        [Required]
        [MaxLength(ModelConstants.Item.TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MaxLength(ModelConstants.Item.DescriptionMaxLength)]
        public string Description { get; set; }
        

        [Required]
        [Display(Name = "Category")]
        public string SubCategoryId { get; set; }

        public ICollection<IFormFile> PictFormFiles { get; set; }

        public IEnumerable<SelectListItem> SubCategories { get; set; }
    }
}
