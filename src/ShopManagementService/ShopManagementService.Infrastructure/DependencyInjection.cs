using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using ShopManagementService.Application.Common.Persistence.Repositories.Base;
using ShopManagementService.Infrastructure.Persistence;
using ShopManagementService.Infrastructure.Persistence.Repositories;

namespace ShopManagementService.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IMongoClient>(sp =>
        {
            var configuration = sp.GetService<IConfiguration>();
            var connectionString = configuration.GetConnectionString("MyMongoDB");
            return new MongoClient(connectionString);
        });
        
        services.AddSingleton<IRepository<Product>, ProductRepository>();
        
        ClassMaps.RegisterClassMaps();
        
        return services;
    }
}