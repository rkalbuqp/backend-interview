namespace InventoryHub.Domain.Exceptions;

public class ProductNotFoundException : DomainException
{
    public ProductNotFoundException(int productId)
        : base($"Produto com ID {productId} não foi encontrado no sistema.")
    {
    }

    public ProductNotFoundException(string message) : base(message)
    {
    }
}
