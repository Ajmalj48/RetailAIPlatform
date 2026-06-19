using RetailAI.ShippingAgent.Models;

namespace RetailAI.CustomerAgent.Services;

public class ShippingApiClient
{
    private readonly HttpClient _httpClient;

    public ShippingApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ShippingRegion> EstimateDelivery(string region)
    {
        return await _httpClient.GetFromJsonAsync<ShippingRegion>
        (
            $"http://localhost:5168/shipping/estimate?region={region}"
        );
    }
}