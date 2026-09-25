using InventoryHub.Domain.Entities;
using InventoryHub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InventoryHub.Infrastructure;

public static class DbInitializer
{
    public static async Task SeedInitialDataAsync(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        if (!await context.Products.AnyAsync())
        {
            await context.Products.AddRangeAsync(new List<Product>
            {
                new() { Name = "Notebook Dell Inspiron 15", Price = 4299.90m, QuantityInStock = 15 },
                new() { Name = "Mouse Gamer Logitech G Pro", Price = 449.90m, QuantityInStock = 42 },
                new() { Name = "Teclado Mecânico RGB", Price = 329.00m, QuantityInStock = 28 },
                new() { Name = "Monitor 27\" Full HD 144Hz", Price = 1899.50m, QuantityInStock = 10 },
                new() { Name = "Headset Bluetooth", Price = 199.90m, QuantityInStock = 60 }
            });
            await context.SaveChangesAsync();
        }
    }
}
