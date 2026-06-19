using RetailAI.InventoryAgent.Models;
using System.Net.Http.Json;

namespace RetailAI.CustomerAgent.Services;

public class InventoryApiClient
{
    private readonly HttpClient _httpClient;

    public InventoryApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Product> CheckInventory(string product)
    {
        return await _httpClient.GetFromJsonAsync<Product>
        (
            $"http://localhost:5036/inventory/check?product={product}"
        );
    }
}