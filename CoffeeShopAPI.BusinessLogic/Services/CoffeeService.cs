using CoffeeShopAPI.BusinessLogic.Contracts;
using CoffeeShopAPI.BusinessLogic.Dtos;
using CoffeeShopAPI.DataAccess.Entities;
using CoffeeShopAPI.DataAccess.Repositories.Coffee;

namespace CoffeeShopAPI.BusinessLogic.Services;

public class CoffeeService : ICoffeeService
{
    private readonly ICoffeeRepository _coffeeRepository;

    public CoffeeService(ICoffeeRepository coffeeRepository)
    {
        _coffeeRepository = coffeeRepository;
    }

    public async Task<IReadOnlyList<CoffeeDto>> Get()
    {
        var coffee = await _coffeeRepository.Get();
        if (coffee == null)
            return new List<CoffeeDto>();

        return coffee.Select( e => new CoffeeDto(
            id: e.Id,
            name: e.Name,
            price: e.Price)).ToList().AsReadOnly();
    }

    public async Task<CoffeeDto> Get(string id)
    {
        var coffee = await _coffeeRepository.Get(id);
        if (coffee == null)
            return CoffeeDto.Default;

        return new CoffeeDto(
            id: coffee.Id,
            name: coffee.Name,
            price: coffee.Price);
    }

    public async Task Add(CoffeeDto coffee)
    {
        if (coffee == CoffeeDto.Default)
            return;

        await _coffeeRepository.Create(new CoffeeEntity
        {
            Id = coffee.Id,
            Name = coffee.Name,
            Price = coffee.Price
        });
    }

    public async Task Update(CoffeeDto coffee)
    {
        if (coffee == CoffeeDto.Default)
            return;

        await _coffeeRepository.Update(new CoffeeEntity
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