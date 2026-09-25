using InventoryHub.Application.DTOs;
using InventoryHub.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryHub.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
    {
        var products = await _productService.GetAllAsync();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> GetById(int id)
    {
        var product = await _productService.GetByIdAsync(id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<ProductDto>> Create([FromBody] ProductCreateDto productDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdProduct = await _productService.CreateAsync(productDto);
        return CreatedAtAction(nameof(GetById), new { id = createdProduct.Id }, createdProduct);
    }

    [HttpPut("{id}/stock")]
    public async Task<IActionResult> UpdateStock(int id, [FromBody] int quantity)
    {
        if (quantity <= 0)
        {
            return BadRequest("A quantidade para baixa deve ser maior que zero.");
        }

        var success = await _productService.UpdateStockAsync(id, quantity);
        if (!success)
        {
            return NotFound("Produto nao encontrado ou estoque insuficiente.");
        }

        return Ok("Estoque atualizado com sucesso.");
    }
}
