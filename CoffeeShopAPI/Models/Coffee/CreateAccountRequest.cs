using System.ComponentModel.DataAnnotations;
using CoffeeShopAPI.DataAccess.Entities;

namespace CoffeeShopAPI.Models.Coffee;

public class CreateCoffeeRequest
{
    [Required]
    public string Name { get; init; }
    [Required]
    public decimal Price { get; init; }
    
}