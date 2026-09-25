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

        // TODO (Candidato) - Bug #1 (análogo useState): 
        // Assim como no React você PRECISA chamar setState para o novo valor refletir no componente,
        // no EF Core você PRECISA chamar SaveChangesAsync() para persistir no banco e receber o Id gerado.
        // Atualmente o Add só altera o ChangeTracker em memória, mas nada é salvo.
        // Descomente a linha abaixo:
        // await _context.SaveChangesAsync();

        return product;
    }

    public async Task UpdateAsync(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }
}
