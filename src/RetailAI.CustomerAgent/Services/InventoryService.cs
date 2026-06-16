using RetailAI.Shared.Models;

namespace RetailAI.CustomerAgent.Services;

public class InventoryService
{
    private readonly HttpClient _httpClient;

    public InventoryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<InventoryResponse?> CheckStock(string product)
    {
        return await _httpClient.GetFromJsonAsync<InventoryResponse>(
            $"https://localhost:7001/api/Inventory/check?product={product}");
    }
}