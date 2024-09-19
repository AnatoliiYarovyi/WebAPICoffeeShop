using System.Collections.ObjectModel;
using CoffeeShopAPI.DataAccess.Entities;

namespace CoffeeShopAPI.DataAccess.Repositories.Orders;

public class OrdersRepository : IOrdersRepository
{
    private readonly CoffeeShopContext _context;

    public OrdersRepository(CoffeeShopContext context)
    {
        _context = context;
    }

    public Task<ReadOnlyCollection<OrderEntity>> Get() =>
        Task.FromResult(_context.Orders.ToList().AsReadOnly());

    public Task<OrderEntity?> Get(string id) =>
        Task.FromResult(_context.Orders.FirstOrDefault(e => e.Id == id));

    public Task<ReadOnlyCollection<OrderEntity>> Get(Func<OrderEntity, bool> predicate)
    {
        return Task.FromResult(_context.Orders.Where(predicate).ToList().AsReadOnly());
    }

    public Task Create(OrderEntity entity)
    {
        _context.Orders.Add(entity);
        return Task.CompletedTask;
    }

    public Task Update(OrderEntity entity)
    {
        foreach (var e in _context.Orders)
        {
            if (e.Id == entity.Id)
            {
                e.CoffeeId = entity.CoffeeId;
                e.CustomerId = entity.CustomerId;
                e.OrderDate = entity.OrderDate;
            }
        }
        return Task.CompletedTask;
    }

    public Task Delete(string id)
    {
        var entity = _context.Orders.FirstOrDefault(e => e.Id == id);
        if (entity != null)
        {
            _context.Orders.Remove(entity);
        }
        return Task.CompletedTask;
    }
}