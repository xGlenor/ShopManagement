using Microsoft.Extensions.DependencyInjection;

namespace ShopManagementService.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediator();
        
        
        return services;
    }
}