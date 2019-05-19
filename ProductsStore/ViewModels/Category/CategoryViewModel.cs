using System.Collections.Generic;

namespace ProductsStore.ViewModels.Category
{
    public class CategoryViewModel
    {
        public string Name { get; set; }

        public IEnumerable<SubCategoryViewModel> SubCategories { get; set; }
    }
}
