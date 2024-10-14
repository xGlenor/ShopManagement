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
    
    [HttpPost("products")]
    public async Task<IActionResult> CreateCinema(Product product)
    {
        var result = await _mediator.Send(
            new CreateProductCommand(product.Id, product.Name, product.Price, product.StockQuantity, product.IsAvailable, DateTime.Now));

        return result.Success
            ? Ok(result.Data)
            : NotFound();
    }
    
}