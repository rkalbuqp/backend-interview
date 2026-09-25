using InventoryHub.Application.Interfaces;
using InventoryHub.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryHub.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();

        return services;
    }
}
