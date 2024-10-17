using Domain.Entities;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using ShopManagementService.Application.Common.Controllers;
using ShopManagementService.Application.Modules.Categories.Commands;
using ShopManagementService.Application.Modules.Categories.Queries;

namespace ShopManagementService.Api.Controllers;

[ApiController]
public class CategoryController: ControllerBase, IController<Category>
{
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("categories")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(GetCategoriesQuery.Instance);
        
        return result.Success 
            ? Ok(result.Data) 
            : NotFound();
    }
    
    [HttpGet("categories/{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var result = await _mediator.Send(new GetCategoryByIdQuery(id));
        
        return result.Success
            ? Ok(result.Data)
            : NotFound();
    }
    [HttpPost("categories")]
    public async Task<IActionResult> Create(Category entity)
    {
        var result = await _mediator.Send(new CreateCategoryCommand(
                entity.Name,
                entity.Description
                ));

        return result.Success
            ? Ok(result.Data)
            : NotFound();
    }

    [HttpPut("categories")]
    public async Task<IActionResult> Update(Category entity)
    {
        var result = await _mediator.Send(new UpdateCategoryCommand(
            entity.Id,
            entity.Name,
            entity.Description
        ));
        
        // Todo zapytać o result.Success czy można zostawić czy trzeba dać Data
        return result.Success
            ? Ok(result.Success)
            : NotFound();
    }
    [HttpDelete("categories/{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var result = await _mediator.Send(new DeleteCategoryCommand(id));

        return result.Success
            ? Ok(result.Success)
            : NotFound();
    }
}