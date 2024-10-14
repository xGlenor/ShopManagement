using Domain.Entities;
using Mapster;
using Mediator;
using ShopManagementService.Application.Common.Persistence.Repositories.Base;
using ShopManagementService.Application.Common.Responses;
using ShopManagementService.Application.Modules.Products.Dtos;

namespace ShopManagementService.Application.Modules.Products.Queries;

public record GetProductQuery : IRequest<Response<IEnumerable<ProductDto>>>
{
    public static readonly GetProductQuery Instance = new();
    
    private GetProductQuery() { }
}

class GetProductQueryHandler : IRequestHandler<GetProductQuery, Response<IEnumerable<ProductDto>>>
{
    private readonly IRepository<Product> _repository;

    public GetProductQueryHandler(IRepository<Product> repository)
    {
        _repository = repository;
    }
    public async ValueTask<Response<IEnumerable<ProductDto>>> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var products = await _repository.GetAllAsync(cancellationToken);
        
        if (products is null)
            return new Response<IEnumerable<ProductDto>> {Success = false};

        return new Response<IEnumerable<ProductDto>>()
        {
            Success = true,
            Data = products.Adapt<IEnumerable<ProductDto>>()
        };
    }
}