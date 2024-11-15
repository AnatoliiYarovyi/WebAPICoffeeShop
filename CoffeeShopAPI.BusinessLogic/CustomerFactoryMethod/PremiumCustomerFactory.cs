using CoffeeShopAPI.BusinessLogic.Dtos;
using System.Text.Json;

namespace CoffeeShopAPI.BusinessLogic.CustomerFactoryMethod
{
    public class PremiumCustomerFactory : IPremiumCustomerFactory
    {
        public CustomerDto CreateCustomer(string name, string email)
        {
            var asd = new CustomerDto(Guid.NewGuid().ToString(), name, email, "Premium", 10);
            Console.WriteLine($"asd: {JsonSerializer.Serialize(asd)}");

            return asd;
        }
    }
}