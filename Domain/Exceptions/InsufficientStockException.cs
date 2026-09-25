namespace InventoryHub.Domain.Exceptions;

public class InsufficientStockException : DomainException
{
    public InsufficientStockException(string productName, int available, int requested)
        : base($"Estoque insuficiente para o produto '{productName}'. Disponível: {available}, Solicitado: {requested}.")
    {
        Available = available;
        Requested = requested;
        ProductName = productName;
    }

    public string ProductName { get; }
    public int Available { get; }
    public int Requested { get; }
}
