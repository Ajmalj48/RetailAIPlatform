namespace RetailAI.CustomerAgent.Services;

public class RecommendationApiClient
{
    private readonly HttpClient _httpClient;

    public RecommendationApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<string>> GetRecommendations(string product)
    {
        return await _httpClient.GetFromJsonAsync<List<string>>
        (
            $"http://localhost:5178/recommendations?product={product}"
        );
    }
}