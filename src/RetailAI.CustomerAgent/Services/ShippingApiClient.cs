namespace RetailAI.CustomerAgent.Services;

public class ShippingApiClient
{
    private readonly HttpClient _httpClient;

    public ShippingApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> EstimateDelivery(
        string region)
    {
        return await _httpClient.GetStringAsync(
            $"http://localhost:5168/shipping/estimate?region={region}");
    }
}