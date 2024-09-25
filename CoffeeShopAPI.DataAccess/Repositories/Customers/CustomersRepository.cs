using System.Collections.ObjectModel;
using CoffeeShopAPI.DataAccess.Entities;

namespace CoffeeShopAPI.DataAccess.Repositories.Customers;

public class CustomersRepository : ICustomersRepository
{
    private readonly CoffeeShopContext _context;

    public CustomersRepository(CoffeeShopContext context)
    {
        _context = context;
    }

    public Task<ReadOnlyCollection<CustomerEntity>> Get() =>
        Task.FromResult(_context.Customers.ToList().AsReadOnly());

    public Task<CustomerEntity?> Get(string id) =>
        Task.FromResult(_context.Customers.FirstOrDefault(e => e.Id == id));

    public Task<ReadOnlyCollection<CustomerEntity>> Get(Func<CustomerEntity, bool> predicate)
    {
        return Task.FromResult(_context.Customers.Where(predicate).ToList().AsReadOnly());
    }

    public Task Create(CustomerEntity entity)
    {
        _context.Customers.Add(entity);
        return Task.CompletedTask;
    }

    public Task Update(CustomerEntity entity)
    {
        foreach (var e in _context.Customers)
        {
            if (e.Id == entity.Id)
            {
                e.Name = entity.Name;
                e.Email = entity.Email;
            }
        }
        return Task.CompletedTask;
    }

    public Task Delete(string id)
    {
        var entity = _context.Customers.FirstOrDefault(e => e.Id == id);
        if (entity != null)
        {
            _context.Customers.Remove(entity);
        }
        return Task.CompletedTask;
    }
}