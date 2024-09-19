using System.ComponentModel.DataAnnotations;
using CoffeeShopAPI.DataAccess.Entities;

namespace CoffeeShopAPI.Models.Coffee;

public class UpdateCoffeeRequest
{
    [Required]
    public string Id { get; init; }
    [Required]
    public decimal Price { get; init; }
    public string Name { get; init; }
}
