using CoffeeShopAPI.DataAccess.Entities;

namespace CoffeeShopAPI
{
    public class CoffeeShopContext
    {
        public ICollection<CoffeeEntity> Coffee { get; }
        public ICollection<OrderEntity> Orders { get; }
        public ICollection<CustomerEntity> Customers { get; }

        public CoffeeShopContext()
        {
            Coffee = new List<CoffeeEntity>()
            {
                new CoffeeEntity
                {
                    Id = "1",
                    Name = "Espresso",
                    Price = 25.50m
                }
            };

            Orders = new List<OrderEntity>()
            {
                new OrderEntity
                {
                    Id = Guid.NewGuid().ToString(),
                    CoffeeId = "1",
                    CustomerId = "1",
                    OrderDate = DateTime.Now
                 }
            };

            Customers = new List<CustomerEntity>()
            {
                new CustomerEntity
                {
                    Id = "1",
                    Name = "John Doe",
                    Email = "john.doe@example.com"
                },
                new CustomerEntity
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "John Doe",
                    Email = "john.doe@example.com"
                }
            };
        }
    }
}