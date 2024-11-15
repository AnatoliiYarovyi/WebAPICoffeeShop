using CoffeeShopAPI.BusinessLogic.Contracts;
using CoffeeShopAPI.BusinessLogic.Dtos;
using Microsoft.Extensions.Logging;

namespace CoffeeShopAPI.BusinessLogic.Decorators
{
    public class LoggingCustomerServiceDecorator : CustomerServiceDecorator
    {
        private readonly ILogger<LoggingCustomerServiceDecorator> _logger;

        public LoggingCustomerServiceDecorator(ICustomersService customersService, ILogger<LoggingCustomerServiceDecorator> logger)
            : base(customersService)
        {
            _logger = logger;
        }

        public override async Task<IReadOnlyList<CustomerDto>> Get()
        {
            _logger.LogInformation("Getting customers");
            return await base.Get();
        }

        public override async Task<IReadOnlyList<CustomerDto>> GetByAdapter()
        {
            _logger.LogInformation("Getting customers by adapter");
            return await base.GetByAdapter();
        }

        public override async Task<CustomerDto> CreateCustomer(string type, string name, string email)
        {
            _logger.LogInformation($"Creating customer: {name}");
            return await base.CreateCustomer(type, name, email);
        }
    }
}