using RetailAI.Shared.Models;

namespace RetailAI.CustomerAgent.Services;

public class RecommendationService
{
    private readonly HttpClient _httpClient;

    public RecommendationService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<RecommendationResponse?> GetRecommendations()
    {
        return await _httpClient.GetFromJsonAsync<RecommendationResponse>(
            "https://localhost:7003/api/Recommendation");
    }
}