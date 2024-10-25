using CoffeeShopAPI.BusinessLogic.Dtos;

namespace CoffeeShopAPI.BusinessLogic.CustomerFactoryMethod

{
    public interface ICustomerFactory
    {
        CustomerDto CreateCustomer(string name, string email);
    }
}
