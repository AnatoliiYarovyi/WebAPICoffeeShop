namespace CoffeeShopAPI.DataAccess.Entities
{
    public class CustomerEntity
    {
        public string Id { get; init; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Grade { get; set; }
        public decimal Discount { get; set; }
    }
}