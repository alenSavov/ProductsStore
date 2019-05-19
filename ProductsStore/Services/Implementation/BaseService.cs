using ProductsStore.Data;

namespace ProductsStore.Services.Implementation
{
    public abstract class BaseService
    {
        protected readonly ApplicationDbContext Context;

        protected BaseService(ApplicationDbContext context)
        {
            this.Context = context;
        }
    }
}
