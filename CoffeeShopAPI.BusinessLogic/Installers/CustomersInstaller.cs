using Microsoft.Extensions.DependencyInjection;
using CoffeeShopAPI.BusinessLogic.CustomerFactoryMethod;
using CoffeeShopAPI.BusinessLogic.Contracts;
using CoffeeShopAPI.BusinessLogic.Services;

namespace CoffeeShopAPI.BusinessLogic.Installers
{
    public static class CustomersInstaller
    {
        public static IServiceCollection AddCustomers(this IServiceCollection services)
        {
            services
                .AddScoped<ICustomersService, CustomersService>()
                .AddScoped<ICustomerFactory, RegularCustomerFactory>()
                .AddScoped<ICustomerFactory, PremiumCustomerFactory>();

            return services;
        }
    }
}