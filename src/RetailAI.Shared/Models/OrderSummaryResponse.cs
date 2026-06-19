namespace RetailAI.Shared.Models;

public class OrderSummaryResponse
{
    public InventoryResponse Inventory { get; set; } = new();

    public ShippingResponse Shipping { get; set; } = new();

    public RecommendationResponse Recommendation { get; set; } = new();
}