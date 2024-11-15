using CoffeeShopAPI.BusinessLogic.Contracts;
using CoffeeShopAPI.BusinessLogic.Dtos;

namespace CoffeeShopAPI.BusinessLogic.Decorators
{
    public class CustomerServiceDecorator : ICustomerServiceDecorator
    {
        protected readonly ICustomersService _customersService;

        public CustomerServiceDecorator(ICustomersService customersService)
        {
            _customersService = customersService;
        }

        public virtual Task<IReadOnlyList<CustomerDto>> Get()
        {
            return _customersService.Get();
        }

        public virtual Task<IReadOnlyList<CustomerDto>> GetByAdapter()
        {
            return _customersService.GetByAdapter();
        }

        public virtual Task<CustomerDto> CreateCustomer(string type, string name, string email)
        {
            return _customersService.CreateCustomer(type, name, email);
        }
    }
}
