using Microsoft.Extensions.DependencyInjection;
using CoffeeShopAPI.DataAccess.Repositories.Coffee;
using CoffeeShopAPI.DataAccess.Repositories.Customers;
using CoffeeShopAPI.DataAccess.Repositories.Orders;

namespace CoffeeShopAPI.DataAccess.Installers;

public static class DataInstaller
{
    public static IServiceCollection AddDataContext(this IServiceCollection services)
    {
        services
            .AddSingleton<CoffeeShopContext>()
            .AddTransient<ICoffeeRepository, CoffeeRepository>()
            .AddTransient<ICustomersRepository, CustomersRepository>()
            .AddTransient<IOrdersRepository, OrdersRepository>();

        return services;
    }
}