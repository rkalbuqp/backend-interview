using System.ComponentModel.DataAnnotations;

namespace InventoryHub.Application.DTOs;

public class ProductCreateDto
{
    [Required(ErrorMessage = "O campo Nome é obrigatório.")]
    [MinLength(2, ErrorMessage = "O Nome deve ter pelo menos 2 caracteres.")]
    public string Name { get; set; } = string.Empty;

    [Range(0.01, double.MaxValue, ErrorMessage = "O Preço deve ser maior que zero.")]
    public decimal Price { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "A quantidade em estoque não pode ser negativa.")]
    public int QuantityInStock { get; set; }
}
