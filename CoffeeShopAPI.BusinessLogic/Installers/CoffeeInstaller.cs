using Microsoft.Extensions.DependencyInjection;
using CoffeeShopAPI.BusinessLogic.Contracts;
using CoffeeShopAPI.BusinessLogic.Services;

namespace CoffeeShopAPI.BusinessLogic.Installers;

public static class CoffeeInstaller
{
    public static IServiceCollection AddCoffee(this IServiceCollection services)
    {
        services.AddScoped<ICoffeeService, CoffeeService>();
        return services;
    }

}