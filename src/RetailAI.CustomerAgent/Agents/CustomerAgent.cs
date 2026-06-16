using RetailAI.CustomerAgent.Services;

namespace RetailAI.CustomerAgent.Agents;

public class CustomerAgent
{
    private readonly InventoryApiClient _inventory;
    private readonly ShippingApiClient _shipping;
    private readonly RecommendationApiClient _recommendation;

    public CustomerAgent(
        InventoryApiClient inventory,
        ShippingApiClient shipping,
        RecommendationApiClient recommendation)
    {
        _inventory = inventory;
        _shipping = shipping;
        _recommendation = recommendation;
    }

    public async Task<string> ProcessRequest(
        string product,
        string region)
    {
        var inventory =
            await _inventory.CheckInventory(product);

        var shipping =
            await _shipping.EstimateDelivery(region);

        var recommendations =
            await _recommendation.GetRecommendations(product);

        return $"""
Inventory

{inventory}

Shipping

{shipping}

Recommendations

{recommendations}
""";
    }
}