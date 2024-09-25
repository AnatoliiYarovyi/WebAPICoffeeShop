namespace CoffeeShopAPI.DataAccess.Entities;

public class ProductsEntity
{
	public string Id { get; init; }
	public string Name { get; set; }
	public decimal Price { get; set; }
}