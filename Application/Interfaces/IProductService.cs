using InventoryHub.Application.DTOs;

namespace InventoryHub.Application.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAllAsync();

    Task<ProductDto?> GetByIdAsync(int id);

    Task<ProductDto> CreateAsync(ProductCreateDto productDto);

    Task<bool> UpdateStockAsync(int id, int quantity);
}
