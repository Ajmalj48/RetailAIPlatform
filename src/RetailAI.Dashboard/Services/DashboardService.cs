using System.Net.Http.Json;
using RetailAI.Dashboard.Models;

namespace RetailAI.Dashboard.Services;

public class DashboardService
{
    private readonly HttpClient _httpClient;

    public DashboardService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> SendMessage(string message)
    {
        var request = new ChatRequest
        {
            UserMessage = message
        };

        var response =
            await _httpClient.PostAsJsonAsync(
                "http://localhost:5031/chat",
                request);

        if (!response.IsSuccessStatusCode)
            return "Unable to connect to CustomerAgent";

        var result =
            await response.Content.ReadFromJsonAsync<ChatResponse>();

        return result?.Response ?? "";
    }
}