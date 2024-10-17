using Domain.Entities;
using Mapster;
using MapsterMapper;
using Mediator;
using ShopManagementService.Application.Common.Persistence.Repositories.Base;
using ShopManagementService.Application.Common.Responses;
using ShopManagementService.Application.Modules.Categories.Dtos;

namespace ShopManagementService.Application.Modules.Categories.Queries;

public record GetCategoryByIdQuery(string Id) : IRequest<Response<CategoryDto>>;

class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, Response<CategoryDto>>
{
    private readonly IRepository<Category> _repository;

    public GetCategoryByIdQueryHandler(IRepository<Category> repository)
    {
        _repository = repository;
    }
    
    public async ValueTask<Response<CategoryDto>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await _repository.GetByIdAsync(request.Id, cancellationToken);
        
        if (category is null) 
            return new Response<CategoryDto>() {Success = false};

        return new Response<CategoryDto>()
        {
            Success = true,
            Data = category.Adapt<CategoryDto>()
        };
    }
}