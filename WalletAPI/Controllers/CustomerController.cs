using Microsoft.AspNetCore.Mvc;
using CoffeeShopAPI.DataAccess.Entities;

namespace CoffeeShopAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly CoffeeShopContext _context;

        public CustomerController(ILogger<CustomerController> logger, CoffeeShopContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("get", Name = "GetCustomers")]
        public IEnumerable<CustomerEntity> GetCustomers()
        {
            try
            {
                return _context.Customers.ToList();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed to fetch customers");
                return null;
            }
        }

        [HttpGet("getById/{id}", Name = "GetCustomerById")]
        public CustomerEntity GetCustomerById([FromRoute] string id)
        {
            try
            {
                return _context.Customers.First(c => c.Id == id);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed to fetch customer");
                return null;
            }
        }

        [HttpPost]
        public void Add([FromBody] CustomerEntity request)
        {
            var customer = new CustomerEntity
            {
                Id = request.Id,
                Name = request.Name,
                Email = request.Email
            };
            try
            {
                _context.Customers.Add(customer);
                _logger.LogInformation($"Customer {customer.Id} successfully created");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to create customer with id={customer.Id}");
            }
        }

        [HttpPut]
        public void Update([FromBody] CustomerEntity request)
        {
            var customer = _context.Customers.First(c => c.Id == request.Id);

            try
            {
                customer.Name = request.Name;
                customer.Email = request.Email;
                _logger.LogInformation($"Customer {customer.Id} successfully updated");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to update customer with id={customer.Id}");
            }
        }

        [HttpDelete]
        public void Remove(string id)
        {
            try
            {
                var customer = _context.Customers.First(c => c.Id == id);
                if (customer != null)
                {
                    _context.Customers.Remove(customer);
                }
                _logger.LogInformation($"Customer {id} successfully deleted");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to delete customer with id={id}");
            }
        }
    }
}
