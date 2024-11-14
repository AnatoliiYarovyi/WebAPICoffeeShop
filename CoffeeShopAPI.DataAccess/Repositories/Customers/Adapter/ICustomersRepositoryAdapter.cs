using System.Collections.ObjectModel;
using CoffeeShopAPI.DataAccess.Entities;

namespace CoffeeShopAPI.DataAccess.Repositories.Customers
{
    public interface ICustomersRepositoryAdapter
    {
        Task<ReadOnlyCollection<CustomerEntity>> GetCustomers();
        Task<CustomerEntity?> GetCustomer(string id);
        Task CreateCustomer(CustomerEntity entity);
        Task UpdateCustomer(CustomerEntity entity);
        Task DeleteCustomer(string id);
    }
}
