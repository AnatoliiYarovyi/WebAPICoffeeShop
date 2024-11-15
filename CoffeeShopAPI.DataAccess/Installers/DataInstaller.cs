using Microsoft.Extensions.DependencyInjection;
using CoffeeShopAPI.DataAccess.Repositories.Products;
using CoffeeShopAPI.DataAccess.Repositories.Customers;
using CoffeeShopAPI.DataAccess.Repositories.Orders;

namespace CoffeeShopAPI.DataAccess.Installers;

public static class DataInstaller
{
    public static IServiceCollection AddDataContext(this IServiceCollection services)
    {
        services
            .AddSingleton<CoffeeShopContext>()
            .AddTransient<IProductsRepository, ProductsRepository>()
            .AddTransient<ICustomersRepository, CustomersRepository>()
            .AddTransient<ICustomersRepositoryAdapter, CustomersRepositoryAdapter>()
            .AddTransient<IOrdersRepository, OrdersRepository>();

        return services;
    }
}