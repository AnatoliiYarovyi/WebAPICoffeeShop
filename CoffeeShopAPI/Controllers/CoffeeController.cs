using Microsoft.AspNetCore.Mvc;
using CoffeeShopAPI.BusinessLogic.Contracts;
using CoffeeShopAPI.BusinessLogic.Dtos;
using CoffeeShopAPI.Models.Coffee;

namespace CoffeeShopAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CoffeeController : ControllerBase
{
    private readonly ILogger<CoffeeController> _logger;
    private readonly ICoffeeService _coffeeService;

    public CoffeeController(ILogger<CoffeeController> logger, ICoffeeService coffeeService)
    {
        _logger = logger;
        _coffeeService = coffeeService;
    }

    [HttpGet("get", Name = "GetAccount")]
    public async Task<ActionResult<IEnumerable<CoffeeDto>>> GetAccount()
    {
        try
        {
            var result = await _coffeeService.Get();
            return Ok(result);
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Failed to fetch accounts");
            return BadRequest();
        }
    }

    [HttpGet("getById/{id}", Name = "GetAccountById")]
    public async Task<ActionResult<CoffeeDto>> GetAccountById([FromRoute] string id)
    {
        try
        {
            var result = await _coffeeService.Get(id);
            return Ok(result);
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Failed to fetch accounts");
            return BadRequest();
        }
    }

    [HttpPost]
    public async Task<ActionResult> Add([FromBody] CreateCoffeeRequest request)
    {
        var entity = new CoffeeDto(
            id: Guid.NewGuid().ToString(),
            name: request.Name,
            price: request.Price);
        try
        {
            await _coffeeService.Add(entity);
            _logger.LogInformation($"Account {entity.Id} successfully created");
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Failed to create account with id={entity.Id}");
            return BadRequest();
        }
    }

    [HttpPut]
    public async Task<ActionResult> Update([FromBody] UpdateCoffeeRequest request)
    {
        var entity = new CoffeeDto(
            id: request.Id,
            name: request.Name,
            price: request.Price);

        try
        {
            await _coffeeService.Update(entity);
            _logger.LogInformation($"Account {entity.Id} successfully updated");
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Failed to update account with id={entity.Id}");
            return BadRequest();
        }
    }

    [HttpDelete]
    public async Task<ActionResult> Remove(string id)
    {
        try
        {
            await _coffeeService.Remove(id);
            _logger.LogInformation($"Account {id} successfully deleted");
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Failed to delete account with id={id}");
            return BadRequest();
        }
    }
}