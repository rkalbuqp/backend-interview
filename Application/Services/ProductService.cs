using InventoryHub.Application.DTOs;
using InventoryHub.Application.Interfaces;
using InventoryHub.Domain.Entities;
using InventoryHub.Domain.Interfaces;

namespace InventoryHub.Application.Services;

public class ProductService : IProductService
{
    // TODO (Candidato): inicializar o campo privado com a dependencia recebida no construtor.
    private readonly IProductRepository? _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        // TODO (Candidato): atribuir a dependencia recebida no campo privado.
        _productRepository = null;
    }

    public async Task<IEnumerable<ProductDto>> GetAllAsync()
    {
        var products = await _productRepository!.GetAllAsync();
        return products.Select(p => new ProductDto
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            QuantityInStock = p.QuantityInStock
        });
    }

    public async Task<ProductDto?> GetByIdAsync(int id)
    {
        var product = await _productRepository!.GetByIdAsync(id);
        if (product == null) return null;

        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            QuantityInStock = product.QuantityInStock
        };
    }

    public async Task<ProductDto> CreateAsync(ProductCreateDto productDto)
    {
        var product = new Product
        {
            Name = productDto.Name,
            Price = productDto.Price,
            QuantityInStock = productDto.QuantityInStock
        };

        var createdProduct = await _productRepository!.CreateAsync(product);

        return new ProductDto
        {
            Id = createdProduct.Id,
            Name = createdProduct.Name,
            Price = createdProduct.Price,
            QuantityInStock = createdProduct.QuantityInStock
        };
    }

    public async Task<bool> UpdateStockAsync(int id, int quantity)
    {
        // TODO (Candidato): implementar a logica de atualizacao de estoque e persistencia no banco.
        throw new NotImplementedException();
    }
}
