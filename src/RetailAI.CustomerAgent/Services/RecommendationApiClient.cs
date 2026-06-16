namespace RetailAI.CustomerAgent.Services;

public class RecommendationApiClient
{
    private readonly HttpClient _httpClient;

    public RecommendationApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GetRecommendations(
        string product)
    {
        return await _httpClient.GetStringAsync(
            $"http://localhost:5178/recommendations?product={product}");
    }
}