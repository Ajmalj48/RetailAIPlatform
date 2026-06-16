using RetailAI.Shared.Models;

namespace RetailAI.CustomerAgent.Services;

public class ShippingService
{
    private readonly HttpClient _client;

    public ShippingService(HttpClient client)
    {
        _client = client;
    }

    public async Task<ShippingResponse?> CheckStock()
    {
        return await _client.GetFromJsonAsync<ShippingResponse>(
            "https://localhost:7001/inventory/check?product=Dell Laptop");
    }
}