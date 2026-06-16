using System.Net.Http.Json;

namespace RetailAI.CustomerAgent.Services;

public class InventoryApiClient
{
    private readonly HttpClient _httpClient;

    public InventoryApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> CheckInventory(string product)
    {
        var response =
            await _httpClient.GetStringAsync(
                $"http://localhost:5036/inventory/check?product={product}");

        return response;
    }
}