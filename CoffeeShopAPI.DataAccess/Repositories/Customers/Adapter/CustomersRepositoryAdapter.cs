using System.Collections.ObjectModel;
using CoffeeShopAPI.DataAccess.Entities;

namespace CoffeeShopAPI.DataAccess.Repositories.Customers
{
    public class CustomersRepositoryAdapter : ICustomersRepositoryAdapter
    {
        private readonly ICustomersRepository _сustomersRepository;

        public CustomersRepositoryAdapter(ICustomersRepository сustomersRepository)
        {
            _сustomersRepository = сustomersRepository;
        }

        public async Task<ReadOnlyCollection<CustomerEntity>> GetCustomers()
        {
            var сustomers = await _сustomersRepository.Get();
            return сustomers.Select(p => new CustomerEntity
            {
                Id = p.Id,
                Name = p.Name,
                Email = $"{p.Name}@adapter.com",
                Grade = "Regular",
                Discount = 0
            }).ToList().AsReadOnly();
        }

        public async Task<CustomerEntity?> GetCustomer(string id)
        {
            var сustomer = await _сustomersRepository.Get(id);
            if (сustomer == null) return null;

            return new CustomerEntity
            {
                Id = сustomer.Id,
                Name = сustomer.Name,
                Email = $"{сustomer.Name}@adapter.com",
                Grade = "Regular",
                Discount = 0
            };
        }
        public async Task CreateCustomer(CustomerEntity entity)
        {
            await _сustomersRepository.Create(entity);
        }

        public async Task UpdateCustomer(CustomerEntity entity)
        {
            await _сustomersRepository.Update(entity);
        }

        public async Task DeleteCustomer(string id)
        {
            await _сustomersRepository.Delete(id);
        }
    }
}
