namespace CoffeeShopAPI.DataAccess.Entities;

public class OrderEntity
{
    public string Id { get; init; }
    public string CoffeeId { get; set; }
    public string CustomerId { get; set; }
    public DateTime OrderDate { get; set; }
 }

