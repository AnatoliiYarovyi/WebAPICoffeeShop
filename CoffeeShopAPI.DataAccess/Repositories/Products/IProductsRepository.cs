using System.Collections.ObjectModel;
using CoffeeShopAPI.DataAccess.Entities;

namespace CoffeeShopAPI.DataAccess.Repositories.Products;

public interface IProductsRepository
{
    public Task<ReadOnlyCollection<ProductsEntity>> Get();
    public Task<ProductsEntity?> Get(string id);
    public Task<ReadOnlyCollection<ProductsEntity>> Get(Func<ProductsEntity, bool> predicate);
    public Task Create(ProductsEntity entity);
    public Task Update(ProductsEntity entity);
    public Task Delete(string id);
}