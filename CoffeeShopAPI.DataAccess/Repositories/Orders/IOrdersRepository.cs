using System.Collections.ObjectModel;
using CoffeeShopAPI.DataAccess.Entities;

namespace CoffeeShopAPI.DataAccess.Repositories.Orders;

public interface IOrdersRepository
{
    public Task<ReadOnlyCollection<OrderEntity>> Get();
    public Task<OrderEntity?> Get(string id);
    public Task<ReadOnlyCollection<OrderEntity>> Get(Func<OrderEntity, bool> predicate);
    public Task Create(OrderEntity entity);
    public Task Update(OrderEntity entity);
    public Task Delete(string id);
}