using Microsoft.AspNetCore.Mvc;
using CoffeeShopAPI.DataAccess.Entities;

namespace CoffeeShopAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly CoffeeShopContext _context;

        public OrderController(ILogger<OrderController> logger, CoffeeShopContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("get", Name = "GetOrders")]
        public IEnumerable<OrderEntity> GetOrders()
        {
            try
            {
                return _context.Orders.ToList();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed to fetch orders");
                return null;
            }
        }

        [HttpGet("getById/{id}", Name = "GetOrderById")]
        public OrderEntity GetOrderById([FromRoute] string id)
        {
            try
            {
                return _context.Orders.First(o => o.Id == id);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed to fetch order");
                return null;
            }
        }

        [HttpPost]
        public void Add([FromBody] OrderEntity request)
        {
            var order = new OrderEntity
            {
                Id = request.Id,
                CoffeeId = request.CoffeeId,
                CustomerId = request.CustomerId,
                OrderDate = request.OrderDate
            };
            try
            {
                _context.Orders.Add(order);
                _logger.LogInformation($"Order {order.Id} successfully created");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to create order with id={order.Id}");
            }
        }

        [HttpPut]
        public void Update([FromBody] OrderEntity request)
        {
            var order = _context.Orders.First(o => o.Id == request.Id);

            try
            {
                order.CoffeeId = request.CoffeeId;
                order.CustomerId = request.CustomerId;
                order.OrderDate = request.OrderDate;
                _logger.LogInformation($"Order {order.Id} successfully updated");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to update order with id={order.Id}");
            }
        }

        [HttpDelete]
        public void Remove(string id)
        {
            try
            {
                var order = _context.Orders.First(o => o.Id == id);
                if (order != null)
                {
                    _context.Orders.Remove(order);
                }
                _logger.LogInformation($"Order {id} successfully deleted");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to delete order with id={id}");
            }
        }
    }
}
