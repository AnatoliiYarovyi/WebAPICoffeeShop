using CoffeeShopAPI.BusinessLogic.Dtos;

namespace CoffeeShopAPI.BusinessLogic.Contracts
{
    public interface ICustomersService
    {
        Task<IReadOnlyList<CustomerDto>> Get();
        Task<IReadOnlyList<CustomerDto>> GetByAdapter();
        Task<CustomerDto> CreateCustomer(string type, string name, string email);
    }
}