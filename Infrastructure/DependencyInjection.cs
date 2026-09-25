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

        // TODO (Candidato) - Bug #2 (análogo useContext / useProvider):
        // Assim como no React, se você chamar useContext() mas NÃO envolveu a árvore
        // com um <Provider value={...}>, o valor será undefined. Aqui no .NET, se você
        // injetar IProductRepository no construtor mas NÃO registrou a implementação,
        // o container DI lança: InvalidOperationException: Unable to resolve service for type 'IProductRepository'
        //
        // Descomente a linha abaixo para "registrar o Provider" desta dependência:
        // services.AddScoped<IProductRepository, EfCoreProductRepository>();

        return services;
    }
}
