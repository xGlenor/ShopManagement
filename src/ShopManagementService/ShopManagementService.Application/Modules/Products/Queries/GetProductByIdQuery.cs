using Domain.Entities;
using Mapster;
using Mediator;
using ShopManagementService.Application.Common.Persistence.Repositories.Base;
using ShopManagementService.Application.Common.Responses;
using ShopManagementService.Application.Modules.Products.Dtos;

namespace ShopManagementService.Application.Modules.Products.Queries;

public record GetProductByIdQuery(string Id) : IRequest<Response<ProductDto>>;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Response<ProductDto>>
{
    private readonly IRepository<Product> _repository;

    public GetProductByIdQueryHandler(IRepository<Product> repository)
    {
        _repository = repository;
    }
    
    public async ValueTask<Response<ProductDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var products = await _repository.GetByIdAsync(request.Id, cancellationToken);
        
        if (products is null)
            return new Response<ProductDto> { Success = false, Message = "Product doesn't exist!"};

        return new Response<ProductDto>
        {
            Success = true,
            Data = products.Adapt<ProductDto>()
        };
    }
}