using Domain.Entities;
using Mapster;
using Mediator;
using ShopManagementService.Application.Common.Persistence.Repositories.Base;
using ShopManagementService.Application.Common.Responses;

namespace ShopManagementService.Application.Modules.Categories.Commands;

public record UpdateCategoryCommand(string Id, string Name, string Description) : IRequest<Response<bool>>;

class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Response<bool>>
{
    private readonly IRepository<Category> _repository;

    public UpdateCategoryCommandHandler(IRepository<Category> repository)
    {
        _repository = repository;
    }


    public async ValueTask<Response<bool>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var categoruToUpdate = request.Adapt<Category>();
        
        var result = await _repository.UpdateAsync(categoruToUpdate, cancellationToken);

        return result
            ? new Response<bool>() { Success = true, Data = true}
            : new Response<bool>() { Success = false, Data = false };
    }
}