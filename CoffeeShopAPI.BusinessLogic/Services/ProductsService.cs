using CoffeeShopAPI.BusinessLogic.Contracts;
using CoffeeShopAPI.BusinessLogic.Dtos;
using CoffeeShopAPI.DataAccess.Entities;
using CoffeeShopAPI.DataAccess.Repositories.Products;

namespace CoffeeShopAPI.BusinessLogic.Services;

public class ProductsService : IProductsService
{
    private readonly IProductsRepository _coffeeRepository;

    public ProductsService(IProductsRepository coffeeRepository)
    {
        _coffeeRepository = coffeeRepository;
    }

    public async Task<IReadOnlyList<ProductsDto>> Get()
    {
        var coffee = await _coffeeRepository.Get();
        if (coffee == null)
            return new List<ProductsDto>();

        return coffee.Select( e => new ProductsDto(
            id: e.Id,
            name: e.Name,
            price: e.Price)).ToList().AsReadOnly();
    }

    public async Task<ProductsDto> Get(string id)
    {
        var coffee = await _coffeeRepository.Get(id);
        if (coffee == null)
            return ProductsDto.Default;

        return new ProductsDto(
            id: coffee.Id,
            name: coffee.Name,
            price: coffee.Price);
    }

    public async Task Add(ProductsDto coffee)
    {
        if (coffee == ProductsDto.Default)
            return;

        await _coffeeRepository.Create(new ProductsEntity
        {
            Id = coffee.Id,
            Name = coffee.Name,
            Price = coffee.Price
        });
    }

    public async Task Update(ProductsDto coffee)
    {
        if (coffee == ProductsDto.Default)
            return;

        await _coffeeRepository.Update(new ProductsEntity
        {
            Id = coffee.Id,
            Name = coffee.Name,
            Price = coffee.Price
        });
    }

    public async Task Remove(string id)
    {
        if (string.IsNullOrEmpty(id))
            throw new ArgumentNullException();

        await _coffeeRepository.Delete(id);
    }
}