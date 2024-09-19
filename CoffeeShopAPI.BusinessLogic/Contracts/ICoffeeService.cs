using CoffeeShopAPI.BusinessLogic.Dtos;

namespace CoffeeShopAPI.BusinessLogic.Contracts;

public interface ICoffeeService
{
    Task<IReadOnlyList<CoffeeDto>> Get();
    Task<CoffeeDto> Get(string id);
    Task Add(CoffeeDto coffee);
    Task Update(CoffeeDto coffee);
    Task Remove(string id);
}