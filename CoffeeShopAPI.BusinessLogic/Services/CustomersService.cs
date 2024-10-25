using CoffeeShopAPI.BusinessLogic.Contracts;
using CoffeeShopAPI.BusinessLogic.CustomerFactoryMethod;
using CoffeeShopAPI.BusinessLogic.Dtos;
using CoffeeShopAPI.DataAccess.Entities;
using CoffeeShopAPI.DataAccess.Repositories.Customers;
using System.Diagnostics;

namespace CoffeeShopAPI.BusinessLogic.Services
{
    public class CustomersService : ICustomersService
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly ICustomerFactory _regularCustomerFactory;
        private readonly ICustomerFactory _premiumCustomerFactory;

        public CustomersService(ICustomersRepository customersRepository, ICustomerFactory regularCustomerFactory, ICustomerFactory premiumCustomerFactory)
        {
            _customersRepository = customersRepository;
            _regularCustomerFactory = regularCustomerFactory;
            _premiumCustomerFactory = premiumCustomerFactory;
        }

        public async Task<IReadOnlyList<CustomerDto>> Get()
        {
            var coffee = await _customersRepository.Get();
            if (coffee == null)
                return new List<CustomerDto>();

            return coffee.Select(static e => new CustomerDto(
                id: e.Id,
                name: e.Name,
                email: e.Email,
                grade: e.Grade,
                discount: e.Discount
                )).ToList().AsReadOnly();
        }

        public async Task<CustomerDto> CreateCustomer(string type, string name, string email)
        {
            CustomerDto customer;
            if (type == "Regular")
            {
                customer = _regularCustomerFactory.CreateCustomer(name, email);
            }
            else if (type == "Premium")
            {
                customer = _premiumCustomerFactory.CreateCustomer(name, email);
            }
            else
            {
                throw new ArgumentException("Invalid customer type");
            }

            var customerEntity = new CustomerEntity
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                Grade = customer.Grade,
                Discount = customer.Discount
            };

            await _customersRepository.Create(customerEntity);
            return customer;
        }
    }
}