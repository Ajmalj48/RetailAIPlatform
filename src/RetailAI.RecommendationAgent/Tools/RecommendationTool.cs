using Microsoft.SemanticKernel;
using RetailAI.RecommendationAgent.Services;

namespace RetailAI.RecommendationAgent.Tools;

public class RecommendationTool
{
    private readonly RecommendationService _service;

    public RecommendationTool(
        RecommendationService service)
    {
        _service = service;
    }

    [KernelFunction]
    public async Task<string> GetRecommendations(
        string product)
    {
        var recommendations =
            await _service.GetRecommendations(product);

        if (!recommendations.Any())
        {
            return "No recommendations found";
        }

        return string.Join(", ", recommendations);
    }
}