namespace InventoryHub.Application.DTOs;

public class StockUpdateResultDto
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public int ProductId { get; set; }
    public int OldStock { get; set; }
    public int NewStock { get; set; }
}
