using ProductsStore.Data;
using ProductsStore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsStore.Services.Implementation
{
    public class CategoriesService : BaseService,ICategoriesService
    {
        public CategoriesService(ApplicationDbContext context) : base(context)
        {

        }

        public Task<IEnumerable<T>> GetAllCategoriesWithSubCategoriesAsync<T>()
        {
            throw new NotImplementedException();
        }
    }
}
