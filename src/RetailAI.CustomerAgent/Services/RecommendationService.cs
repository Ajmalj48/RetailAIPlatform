using RetailAI.Shared.Models;

namespace RetailAI.CustomerAgent.Services;

public class RecommendationService
{
    private readonly HttpClient _client;

    public RecommendationService(HttpClient client)
    {
        _client = client;
    }

    public async Task<RecommendationResponse?> CheckStock()
    {
        return await _client.GetFromJsonAsync<RecommendationResponse>(
            "https://localhost:7001/inventory/check?product=Dell Laptop");
    }
}