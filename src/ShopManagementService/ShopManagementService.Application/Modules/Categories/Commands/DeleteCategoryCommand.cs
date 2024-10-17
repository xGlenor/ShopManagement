using Domain.Entities;
using Mediator;
using ShopManagementService.Application.Common.Persistence.Repositories.Base;
using ShopManagementService.Application.Common.Responses;

namespace ShopManagementService.Application.Modules.Categories.Commands;

public record DeleteCategoryCommand(string CategoryId) : IRequest<Response<bool>>;

class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Response<bool>>
{
    private readonly IRepository<Category> _repository;

    public DeleteCategoryCommandHandler(IRepository<Category> repository)
    {
        _repository = repository;
    }

    public async ValueTask<Response<bool>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var deleteCategory = await _repository.DeleteAsync(request.CategoryId, cancellationToken);
        
        return deleteCategory
            ? new Response<bool> {Success = true}
            : new Response<bool> {Success = false};
    }
}