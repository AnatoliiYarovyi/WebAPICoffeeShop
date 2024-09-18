using Microsoft.AspNetCore.Mvc;
using CoffeeShopAPI.DataAccess.Entities;

namespace CoffeeShopAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoffeeController : ControllerBase
    {
        private readonly ILogger<CoffeeController> _logger;
        private readonly CoffeeShopContext _context = new CoffeeShopContext();

        public CoffeeController(ILogger<CoffeeController> logger, CoffeeShopContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("get", Name = "GetCoffees")]
        public IEnumerable<CoffeeEntity> GetCoffees()
        {
            try
            {
                return _context.Coffees.ToList();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed to fetch coffees");
                return null;
            }
        }

        [HttpGet("getById/{id}", Name = "GetCoffeeById")]
        public CoffeeEntity GetCoffeeById([FromRoute] string id)
        {
            try
            {
                return _context.Coffees.First(c => c.Id == id);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed to fetch coffee");
                return null;
            }
        }

        [HttpPost]
        public void Add([FromBody] CoffeeEntity request)
        {
            var coffee = new CoffeeEntity
            {
                Id = request.Id,
                Name = request.Name,
                Price = request.Price
            };
            try
            {
                _context.Coffees.Add(coffee);
                _logger.LogInformation($"Coffee {coffee.Id} successfully created");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to create coffee with id={coffee.Id}");
            }
        }

        [HttpPut]
        public void Update([FromBody] CoffeeEntity request)
        {
            var coffee = _context.Coffees.First(c => c.Id == request.Id);

            try
            {
                coffee.Name = request.Name;
                coffee.Price = request.Price;
                _logger.LogInformation($"Coffee {coffee.Id} successfully updated");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to update coffee with id={coffee.Id}");
            }
        }

        [HttpDelete]
        public void Remove(string id)
        {
            try
            {
                var coffee = _context.Coffees.First(c => c.Id == id);
                if (coffee != null)
                {
                    _context.Coffees.Remove(coffee);
                }
                _logger.LogInformation($"Coffee {id} successfully deleted");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to delete coffee with id={id}");
            }
        }
    }
}
