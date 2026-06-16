using RetailAI.Shared.Models;

namespace RetailAI.CustomerAgent.Services;

public class ShippingService
{
    private readonly HttpClient _httpClient;

    public ShippingService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ShippingResponse?> GetDeliveryEstimate()
    {
        return await _httpClient.GetFromJsonAsync<ShippingResponse>(
            "https://localhost:7002/api/Shipping/estimate");
    }
}