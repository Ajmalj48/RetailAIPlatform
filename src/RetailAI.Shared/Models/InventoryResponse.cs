namespace RetailAI.Shared.Models;

public class InventoryResponse
{
    public bool Available { get; set; }

    public int Quantity { get; set; }

    public string Product { get; set; } = "";
}