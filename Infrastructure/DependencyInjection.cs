using InventoryHub.Domain.Interfaces;
using InventoryHub.Infrastructure.Data;
using InventoryHub.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryHub.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseInMemoryDatabase("InventoryDb"));

        // TODO (Candidato): registrar a implementacao de IProductRepository no container de DI.

        return services;
    }
}
