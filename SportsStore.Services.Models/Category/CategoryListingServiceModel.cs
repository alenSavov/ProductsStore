using System;
using System.Collections.Generic;
using System.Text;

namespace SportsStore.Services.Models.Category
{
    public class CategoryListingServiceModel : BaseCategoryServiceModel
    {
        public string Name { get; set; }

        public IEnumerable<SubCategoryListingServiceModel> SubCategories { get; set; }
    }
}
