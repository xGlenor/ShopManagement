using Domain.Entities;
using Mediator;
using ShopManagementService.Application.Common.Persistence.Repositories.Base;
using ShopManagementService.Application.Common.Responses;

namespace ShopManagementService.Application.Modules.Products.Commands;

public record DeleteProductCommand(string Id) : IRequest<Response<bool>>;

class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Response<bool>>
{
    private readonly IRepository<Product> _productRepository;

    public DeleteProductCommandHandler(IRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }

    public async ValueTask<Response<bool>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var deletedResult = await _productRepository.DeleteAsync(request.Id, cancellationToken);

        return deletedResult
            ? new Response<bool> { Success = true }
            : new Response<bool> { Success = false };
    }
}