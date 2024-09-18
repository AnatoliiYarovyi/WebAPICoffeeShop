namespace CoffeeShopAPI.DataAccess.Entities;

 public class CoffeeEntity
{
    public string Id { get; init; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}