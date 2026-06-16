using RetailAI.Shared.Models;

namespace RetailAI.CustomerAgent.Services;

public class InventoryService
{
    private readonly HttpClient _client;

    public InventoryService(HttpClient client)
    {
        _client = client;
    }

    public async Task<InventoryResponse?> CheckStock()
    {
        return await _client.GetFromJsonAsync<InventoryResponse>(
            "https://localhost:7001/inventory/check?product=Dell Laptop");
    }
}