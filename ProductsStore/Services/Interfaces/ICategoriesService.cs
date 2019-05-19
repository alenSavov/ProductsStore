using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsStore.Services.Interfaces
{
    public interface ICategoriesService 
    {
        Task<IEnumerable<T>> GetAllCategoriesWithSubCategoriesAsync<T>();
    }
}
