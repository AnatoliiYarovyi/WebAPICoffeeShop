using System.Collections.ObjectModel;
using CoffeeShopAPI.DataAccess.Entities;

namespace CoffeeShopAPI.DataAccess.Repositories.Customers
{
    public interface ICustomersRepository
    {
        public Task<ReadOnlyCollection<CustomerEntity>> Get();
        public Task<CustomerEntity?> Get(string id);
        public Task<ReadOnlyCollection<CustomerEntity>> Get(Func<CustomerEntity, bool> predicate);
        public Task Create(CustomerEntity entity);
        public Task Update(CustomerEntity entity);
        public Task Delete(string id);
    }
}