using Microsoft.AspNetCore.Mvc;
using CoffeeShopAPI.BusinessLogic.Contracts;
using CoffeeShopAPI.BusinessLogic.Dtos;
using CoffeeShopAPI.Models.Products;

namespace CoffeeShopAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ILogger<ProductsController> _logger;
    private readonly IProductsService _productService;

    public ProductsController(ILogger<ProductsController> logger, IProductsService productsService)
    {
        _logger = logger;
        _productService = productsService;
    }

    [HttpGet("get", Name = "GetProducts")]
    public async Task<ActionResult<IEnumerable<ProductsDto>>> GetProducts()
    {
        try
        {
            var result = await _productService.Get();
            return Ok(result);
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Failed to fetch products");
            return BadRequest();
        }
    }

    [HttpGet("getById/{id}", Name = "GetProductById")]
    public async Task<ActionResult<ProductsDto>> GetProductById([FromRoute] string id)
    {
        try
        {
            var result = await _productService.Get(id);
            return Ok(result);
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Failed to fetch products");
            return BadRequest();
        }
    }

    [HttpPost(Name = "AddNewProduct")]
    public async Task<ActionResult> Add([FromBody] CreateProductRequest request)
    {
        var entity = new ProductsDto(
            id: Guid.NewGuid().ToString(),
            name: request.Name,
            price: request.Price);
        try
        {
            await _productService.Add(entity);
            _logger.LogInformation($"Product {entity.Id} successfully created");
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Failed to create product with id={entity.Id}");
            return BadRequest();
        }
    }

    [HttpPut]
    public async Task<ActionResult> Update([FromBody] UpdateProductRequest request)
    {
        var entity = new ProductsDto(
            id: request.Id,
            name: request.Name,
            price: request.Price);

        try
        {
            await _productService.Update(entity);
            _logger.LogInformation($"Product {entity.Id} successfully updated");
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Failed to update product with id={entity.Id}");
            return BadRequest();
        }
    }

    [HttpDelete]
    public async Task<ActionResult> Remove(string id)
    {
        try
        {
            await _productService.Remove(id);
            _logger.LogInformation($"Product {id} successfully deleted");
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Failed to delete product with id={id}");
            return BadRequest();
        }
    }
}