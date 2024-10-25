using CoffeeShopAPI.BusinessLogic.Dtos;

namespace CoffeeShopAPI.BusinessLogic.Contracts
{
    public interface ICustomersService
    {
        Task<IReadOnlyList<CustomerDto>> Get();
        Task<CustomerDto> CreateCustomer(string type, string name, string email);
    }
}