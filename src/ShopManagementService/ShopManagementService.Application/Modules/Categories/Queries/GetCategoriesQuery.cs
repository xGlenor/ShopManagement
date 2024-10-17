using Domain.Entities;
using Mapster;
using Mediator;
using ShopManagementService.Application.Common.Persistence.Repositories.Base;
using ShopManagementService.Application.Common.Responses;
using ShopManagementService.Application.Modules.Categories.Dtos;

namespace ShopManagementService.Application.Modules.Categories.Queries;

public record GetCategoriesQuery : IRequest<Response<IEnumerable<CategoryDto>>>
{
    public static readonly GetCategoriesQuery Instance = new();
    
    private GetCategoriesQuery() { }
}

class GetCategoryQueryHandler : IRequestHandler<GetCategoriesQuery, Response<IEnumerable<CategoryDto>>>
{
    private readonly IRepository<Category> _repository;

    public GetCategoryQueryHandler(IRepository<Category> repository)
    {
        _repository = repository;
    }

    public async ValueTask<Response<IEnumerable<CategoryDto>>> Handle(GetCategoriesQuery request,
        CancellationToken cancellationToken)
    {
        var products = await _repository.GetAllAsync(cancellationToken);

        if (products is null)
            return new Response<IEnumerable<CategoryDto>>() { Success = false };

        return new Response<IEnumerable<CategoryDto>>()
        {
            Success = true,
            Data = products.Adapt<IEnumerable<CategoryDto>>()
        };
    }
}