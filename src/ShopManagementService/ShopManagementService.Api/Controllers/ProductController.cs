using Domain.Entities;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using ShopManagementService.Application.Modules.Products.Commands;
using ShopManagementService.Application.Modules.Products.Queries;

namespace ShopManagementService.Api.Controllers;

[ApiController]
public class ProductController: ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("products")]
    public async Task<IActionResult> GetProducts()
    {
        var result = await _mediator.Send(GetProductQuery.Instance);

        return result.Success
            ? Ok(result.Data)
            : NotFound();
    }

    [HttpGet("products/{id}")]
    public async Task<IActionResult> GetProduct(string id)
    {
        var result = await _mediator.Send(new GetProductByIdQuery(id));
        
        return result.Success 
            ? Ok(result.Data)
            : NotFound();
    }
    
    
    [HttpPost("products")]
    public async Task<IActionResult> CreateCinema(Product product)
    {
        var result = await _mediator.Send(
            new CreateProductCommand(product.Name, product.Description, product.Price, product.StockQuantity, product.IsAvailable, DateTime.Now));

        return result.Success
            ? Ok(result.Data)
            : NotFound();
    }

    [HttpPut("products/{id}")]
    public async Task<IActionResult> UpdateCinema(Product product)
    {
        var result = await _mediator.Send(new UpdateProductCommand(
            product.Id, product.Name, product.Description, product.Price, product.StockQuantity, product.IsAvailable
        ));
        
        
        return result.Success
            ? Ok(result.Data)
            : NotFound();
    }
    
    [HttpDelete("products/{id}")]
    public async Task<IActionResult> DeleteProduct(string id)
    {
        var result = await _mediator.Send(new DeleteProductCommand(id));
        
        return result.Success
            ? Ok(result.Data)
            : NotFound();
    }
    
}