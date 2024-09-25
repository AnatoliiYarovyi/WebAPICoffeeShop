using System.ComponentModel.DataAnnotations;
using CoffeeShopAPI.DataAccess.Entities;

namespace CoffeeShopAPI.Models.Products;

public class CreateProductRequest
{
    [Required]
    public string Name { get; init; }
    [Required]
    public decimal Price { get; init; }
    
}