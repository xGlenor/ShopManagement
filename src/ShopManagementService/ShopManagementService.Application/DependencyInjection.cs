using Domain.Entities;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using ShopManagementService.Application.Modules.Products.Dtos;

namespace ShopManagementService.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediator();

        /*TypeAdapterConfig<Product, ProductDto>
            .NewConfig();*/
        
        return services;
    }
}