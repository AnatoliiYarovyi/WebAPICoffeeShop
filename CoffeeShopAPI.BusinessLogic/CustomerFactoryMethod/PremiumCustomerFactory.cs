using CoffeeShopAPI.BusinessLogic.Dtos;

namespace CoffeeShopAPI.BusinessLogic.CustomerFactoryMethod
{
    public class PremiumCustomerFactory : ICustomerFactory
    {
        public CustomerDto CreateCustomer(string name, string email)
        {
            return new CustomerDto(Guid.NewGuid().ToString(), name, email, "Premium", 10);
        }
    }
}