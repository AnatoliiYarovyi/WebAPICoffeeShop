using AutoMapper.Internal;
using CoffeeShopAPI.DataAccess.Entities;

namespace CoffeeShopAPI.BusinessLogic.Dtos;

public class CoffeeDto : IEquatable<CoffeeDto>
{
    public static readonly CoffeeDto Default
        = new CoffeeDto(string.Empty, string.Empty, decimal.Zero);

    public string Id { get; }
    public string Name { get; }
    public decimal Price { get; }

    public CoffeeDto(string id, string name, decimal price)
    {
        Id = id;
        Name = name;
        Price = price;
    }

    public bool Equals(CoffeeDto? other)
    {
        if (other == null)
            return false;

        return Id == other.Id && Name == other.Name && Price == other.Price;

    }

    public override int GetHashCode()
    {
        return (Id.GetHashCode() + Name.GetHashCode() + Price.GetHashCode() * 45);
    }
}