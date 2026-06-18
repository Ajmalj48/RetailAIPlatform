using RetailAI.Dashboard.Models;
using System.Net.Http.Json;

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
        {
            var error = await response.Content.ReadAsStringAsync();

            return $"Status={response.StatusCode}\n{error}";
        }

        var result =
            await response.Content.ReadFromJsonAsync<ChatResponse>();

        return result?.Response ?? "";
    }

    public async Task<FlowState?> GetFlow()
    {
        return await _httpClient.GetFromJsonAsync<FlowState>
        (
            "http://localhost:5031/flow"
        );
    }
}