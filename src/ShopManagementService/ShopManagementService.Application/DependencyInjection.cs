using Domain.Entities;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using ShopManagementService.Application.Common.Persistence.Repositories.RabbitMQ;
using ShopManagementService.Application.Common.RabbitMQ;
using ShopManagementService.Application.Modules.Products.Dtos;

namespace ShopManagementService.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediator();

        services.AddSingleton<IRabbitMqConnection>(new RabbitMQConnection());
        services.AddScoped<IMessageSender, RabbitMqSender>();
        
        /*TypeAdapterConfig<Product, ProductDto>
            .NewConfig();*/
        
        return services;
    }
}