using CoffeeShopAPI.BusinessLogic.Dtos;

namespace CoffeeShopAPI.BusinessLogic.Contracts;

public interface IProductsService
{
    Task<IReadOnlyList<ProductsDto>> Get();
    Task<ProductsDto> Get(string id);
    Task Add(ProductsDto coffee);
    Task Update(ProductsDto coffee);
    Task Remove(string id);
}