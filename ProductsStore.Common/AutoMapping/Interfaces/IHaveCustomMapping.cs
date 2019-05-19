using AutoMapper;

namespace ProductsStore.Common.AutoMapping.Interfaces
{
    public interface IHaveCustomMapping
    {
        void ConfigureMapping(Profile mapper);
    }
}
