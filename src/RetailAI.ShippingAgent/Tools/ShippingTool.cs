using Microsoft.SemanticKernel;
using RetailAI.ShippingAgent.Services;

namespace RetailAI.ShippingAgent.Tools;

public class ShippingTool
{
    private readonly ShippingService _shippingService;

    public ShippingTool(
        ShippingService shippingService)
    {
        _shippingService = shippingService;
    }

    [KernelFunction]
    public async Task<string> EstimateDelivery(
        string region)
    {
        var shipping =
            await _shippingService.GetShippingInfo(region);

        if (shipping == null)
        {
            return "Shipping information unavailable";
        }

        return
            $"Delivery to {shipping.Region} takes {shipping.DeliveryDays} days. Shipping cost is ₹{shipping.ShippingCost}";
    }
}