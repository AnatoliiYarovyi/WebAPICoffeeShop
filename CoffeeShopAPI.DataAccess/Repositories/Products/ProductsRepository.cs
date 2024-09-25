using System.Collections.ObjectModel;
using CoffeeShopAPI.DataAccess.Entities;

namespace CoffeeShopAPI.DataAccess.Repositories.Products;

public class ProductsRepository : IProductsRepository
{
    private readonly CoffeeShopContext _context;

    public ProductsRepository(CoffeeShopContext context)
    {
        _context = context;
    }

    public Task<ReadOnlyCollection<ProductsEntity>> Get() =>
        Task.FromResult(_context.Products.ToList().AsReadOnly());

    public Task<ProductsEntity?> Get(string id) =>
        Task.FromResult(_context.Products.FirstOrDefault(e => e.Id == id));

    public Task<ReadOnlyCollection<ProductsEntity>> Get(Func<ProductsEntity, bool> predicate)
    {
        return Task.FromResult(_context.Products.Where(predicate).ToList().AsReadOnly());
    }

    public Task Create(ProductsEntity entity)
    {
        _context.Products.Add(entity);
        return Task.CompletedTask;
    }

    public Task Update(ProductsEntity entity)
    {
        foreach (var e in _context.Products)
        {
            if (e.Id == entity.Id)
            {
                e.Name = entity.Name;
                e.Price = entity.Price;
            }
        }
        return Task.CompletedTask;
    }

    public Task Delete(string id)
    {
        var entity = _context.Products.FirstOrDefault(e => e.Id == id);
        if (entity != null)
        {
            _context.Products.Remove(entity);
        }
        return Task.CompletedTask;
    }
}