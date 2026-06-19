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
            Extract the product name and region.

            Respond with ONLY valid JSON.

            No markdown.
            No explanation.

            Example:

            {"Product":"Dell Inspiron","Region":"Kerala"}

            User request:

            {{userInput}}
            """;

        var response = "";

        await foreach (var token in _ollama.GenerateAsync(prompt))
        {
            response += token.Response;
        }

        response = response
    .Replace("```json", "")
    .Replace("```", "")
    .Trim();

        Console.WriteLine("OLLAMA RESPONSE:");
        Console.WriteLine(response);

        try
        {
            var start = response.IndexOf('{');
            var end = response.IndexOf('}') + 1;

            var json = response[start..end];

            Console.WriteLine("JSON USED:");
            Console.WriteLine(json);

            var info =
                JsonSerializer.Deserialize<QueryInfo>(
                    json,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

            return info ?? new QueryInfo();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);

            return new QueryInfo();
        }
    }
}