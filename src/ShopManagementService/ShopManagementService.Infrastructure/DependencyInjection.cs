using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

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
        
        return services;
    }
}