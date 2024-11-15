using CoffeeShopAPI.BusinessLogic.Dtos;
using System.Text.Json;

namespace CoffeeShopAPI.BusinessLogic.CustomerFactoryMethod
{
    public class RegularCustomerFactory : IRegularCustomerFactory
    {
        public CustomerDto CreateCustomer(string name, string email)
        {
            var qwe = new CustomerDto(Guid.NewGuid().ToString(), name, email, "Regular", 3);
            Console.WriteLine($"qwe: {JsonSerializer.Serialize(qwe)}");

            return qwe;
        }
    }
}
