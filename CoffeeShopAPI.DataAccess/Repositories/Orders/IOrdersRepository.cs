using System.Collections.ObjectModel;
using CoffeeShopAPI.DataAccess.Entities;

namespace CoffeeShopAPI.DataAccess.Repositories.Orders;

public interface IOrdersRepository
{
    public Task<ReadOnlyCollection<CoffeeEntity>> Get();
    public Task<CoffeeEntity?> Get(string id);
    public Task<ReadOnlyCollection<CoffeeEntity>> Get(Func<CoffeeEntity, bool> predicate);
    public Task Create(CoffeeEntity entity);
    public Task Update(CoffeeEntity entity);
    public Task Delete(string id);
}