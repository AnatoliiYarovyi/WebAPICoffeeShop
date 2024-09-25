using Microsoft.Extensions.DependencyInjection;
using CoffeeShopAPI.BusinessLogic.Contracts;
using CoffeeShopAPI.BusinessLogic.Services;

namespace CoffeeShopAPI.BusinessLogic.Installers;

public static class ProductsInstaller
{
    public static IServiceCollection AddProducts(this IServiceCollection services)
    {
        services.AddScoped<IProductsService, ProductsService>();
        return services;
    }

}