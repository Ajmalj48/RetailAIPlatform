using RetailAI.CustomerAgent.Services;

namespace RetailAI.CustomerAgent.Agents;

public class CustomerAgent
{
    private readonly InventoryApiClient _inventory;
    private readonly ShippingApiClient _shipping;
    private readonly RecommendationApiClient _recommendation;
    private readonly OllamaService _ollama;

    public CustomerAgent(
        InventoryApiClient inventory,
        ShippingApiClient shipping,
        RecommendationApiClient recommendation,
        OllamaService ollama)
    {
        _inventory = inventory;
        _shipping = shipping;
        _recommendation = recommendation;
        _ollama = ollama;
    }

    public async Task<string> ProcessRequest(
        string request)
    {
        var info =
            await _ollama.ExtractInformation(request);

        var inventory =
            await _inventory.CheckInventory(
                info.Product);

        var shipping =
            await _shipping.EstimateDelivery(
                info.Region);

        var recommendation =
            await _recommendation.GetRecommendations(
                info.Product);

        return
$"""
Product:
{info.Product}

Region:
{info.Region}

Inventory:

{inventory}

Shipping:

{shipping}

Recommendations:

{recommendation}
""";
    }
}