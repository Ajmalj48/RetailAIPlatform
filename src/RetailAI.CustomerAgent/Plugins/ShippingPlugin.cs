using Microsoft.SemanticKernel;
using RetailAI.CustomerAgent.Services;

namespace RetailAI.CustomerAgent.Plugins;

public class ShippingPlugin
{
    private readonly ShippingService _shippingService;

    public ShippingPlugin(ShippingService shippingService)
    {
        _shippingService = shippingService;
    }

    [KernelFunction]
    public async Task<string> EstimateDelivery()
    {
        var response = await _shippingService.GetDeliveryEstimate();

        if (response == null)
            return "Unable to estimate delivery.";

        return $"Estimated delivery time is {response.DeliveryDays} days.";
    }
}