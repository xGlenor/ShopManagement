using Domain.Entities;
using Mapster;
using Mediator;
using ShopManagementService.Application.Common.Persistence.Repositories.Base;
using ShopManagementService.Application.Common.Responses;

namespace ShopManagementService.Application.Modules.Categories.Commands;

public record CreateCategoryCommand(
    string Name,
    string Description
    ): IRequest<Response<string>>;
    
class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Response<string>>
{
    private readonly IRepository<Category> _repository;

    public CreateCategoryCommandHandler(IRepository<Category> repository)
    {
        _repository = repository;
    }

    public async ValueTask<Response<string>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var categoryToAdd = request.Adapt<Category>();
        
        var result = await _repository.AddAsync(categoryToAdd, cancellationToken);
        
        if(result is null)
            return new Response<string>() {Success = false};
        
        return new Response<string>() {Success = true, Data = result.Id};
    }
}