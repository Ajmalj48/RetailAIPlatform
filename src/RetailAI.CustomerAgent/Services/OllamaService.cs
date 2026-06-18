using System.Text.Json;
using OllamaSharp;
using RetailAI.CustomerAgent.Models;

namespace RetailAI.CustomerAgent.Services;

public class OllamaService
{
    private readonly OllamaApiClient _ollama;

    public OllamaService(IConfiguration configuration)
    {
        var url = configuration["Ollama:Url"];
        var model = configuration["Ollama:Model"];

        _ollama = new OllamaApiClient(
            new Uri(url!));

        _ollama.SelectedModel = model!;
    }

    public async Task<QueryInfo> ExtractInformation(
        string userInput)
    {
        var prompt =
                    $$"""
                    Extract the product and region.

                    Return ONLY JSON.

                    Example:

                    {
                        "Product":"Dell Inspiron 15",
                        "Region":"Kerala"
                    }

                    User request:

                    {{userInput}}
                    """;

        var response = "";

        await foreach (var token in _ollama.GenerateAsync(prompt))
        {
            response += token.Response;
        }

        try
        {
            return JsonSerializer.Deserialize<QueryInfo>(
                response,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                })!;
        }
        catch
        {
            return new QueryInfo();
        }
    }
}