using InventoryHub.Application.DTOs;
using InventoryHub.Application.Interfaces;
using InventoryHub.Domain.Entities;
using InventoryHub.Domain.Interfaces;

namespace InventoryHub.Application.Services;

public class ProductService : IProductService
{
    // TODO (Candidato) - Bug #3 (análogo useProvider): Campo privado declarado mas NÃO inicializado no construtor.
    // Assim como no React você precisa receber o "value" do Provider no useContext, aqui o repository
    // recebido no construtor deve ser atribuído a este campo.
    // Atualmente o campo ficará null e causará NullReferenceException em runtime.
    // Corrija: remova o "= null!" e atribua corretamente no construtor.
    private readonly IProductRepository? _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        // TODO (Candidato) - Bug #3: Descomente a linha abaixo e remova a atribuição de null.
        // _productRepository = productRepository;
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
        // TODO (Candidato) - Bug #4 (análogo useState setter incompleto): 
        // Assim como no React você tem que chamar setX(prev => prev - qtd) para atualizar estado,
        // aqui você precisa implementar a lógica de atualizar o estoque no banco:
        //
        // 1. Use _productRepository.GetByIdAsync(id) para buscar o produto
        // 2. Se o produto não existir, retorne false
        // 3. Valide se product.QuantityInStock >= quantity (estoque suficiente para baixa)
        // 4. Se estoque insuficiente, retorne false
        // 5. Decremente: product.QuantityInStock -= quantity
        // 6. Use _productRepository.UpdateAsync(product) para salvar a alteração
        // 7. Retorne true
        throw new NotImplementedException("TODO: Implemente a logica de baixa de estoque e persista no banco.");
    }
}
