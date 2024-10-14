using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace ShopManagementService.Api.Controllers;

[ApiController]
public class ProductController: ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }
}