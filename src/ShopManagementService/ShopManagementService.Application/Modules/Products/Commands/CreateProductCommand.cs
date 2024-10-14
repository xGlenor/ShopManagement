using Domain.Entities;
using Mapster;
using Mediator;
using ShopManagementService.Application.Common.Persistence.Repositories.Base;
using ShopManagementService.Application.Common.Responses;

namespace ShopManagementService.Application.Modules.Products.Commands;

public record CreateProductCommand
(
    string Name,
    string Description,
    decimal Price,
    int StockQuantity,
    bool IsAvailable,
    DateTime CreatedDate
) : IRequest<Response<string>>;

class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Response<string>>
{
    private readonly IRepository<Product> _repository;

    public CreateProductCommandHandler(IRepository<Product> repository)
    {
        _repository = repository;
    }

    public async ValueTask<Response<string>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var productToAdd = request.Adapt<Product>();
        
        var result = await _repository.AddAsync(productToAdd, cancellationToken);
        
        if (result is null)
            return new Response<string> { Success = false };

        return new Response<string>
        {
            Success = true,
            Data = result.Id
        };
    }
}