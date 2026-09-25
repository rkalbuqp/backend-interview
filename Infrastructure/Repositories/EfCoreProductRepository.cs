using InventoryHub.Domain.Entities;
using InventoryHub.Domain.Interfaces;
using InventoryHub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InventoryHub.Infrastructure.Repositories;

public class EfCoreProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public EfCoreProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Product> CreateAsync(Product product)
    {
        _context.Products.Add(product);

        // TODO (Candidato): persistir as alteracoes no banco.

        return product;
    }

    public async Task UpdateAsync(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }
}
