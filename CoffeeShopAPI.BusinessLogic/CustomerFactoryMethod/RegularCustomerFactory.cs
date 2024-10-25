using CoffeeShopAPI.BusinessLogic.Dtos;

namespace CoffeeShopAPI.BusinessLogic.CustomerFactoryMethod
{
    public class RegularCustomerFactory : ICustomerFactory
    {
        public CustomerDto CreateCustomer(string name, string email)
        {
            return new CustomerDto(Guid.NewGuid().ToString(), name, email, "Regular", 0);
        }
    }
}
