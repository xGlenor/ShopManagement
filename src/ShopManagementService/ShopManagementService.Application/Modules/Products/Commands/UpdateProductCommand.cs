using Domain.Entities;
using Mapster;
using MapsterMapper;
using Mediator;
using ShopManagementService.Application.Common.Persistence.Repositories.Base;
using ShopManagementService.Application.Common.Responses;

namespace ShopManagementService.Application.Modules.Products.Commands;

public record UpdateProductCommand(
    string Id,
    string Name,
    string Description,
    decimal Price,
    int StockQuantity,
    bool IsAvailable
) : IRequest<Response<bool>>;

class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Response<bool>>
{
    private readonly IRepository<Product> _productRepository;

    public UpdateProductCommandHandler(IRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }

    public async ValueTask<Response<bool>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var productToUpdate = request.Adapt<Product>();
        
        var updateResult = await _productRepository.UpdateAsync(productToUpdate, cancellationToken);
        // Todo -> Zapytać o to data, czy tak powinno być
        return updateResult
            ? new Response<bool> { Success = true, Data = true}
            : new Response<bool> { Success = false, Data = false };
    }
}