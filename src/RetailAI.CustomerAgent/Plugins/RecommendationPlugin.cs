using Microsoft.SemanticKernel;
using RetailAI.CustomerAgent.Services;

namespace RetailAI.CustomerAgent.Plugins;

public class RecommendationPlugin
{
    private readonly RecommendationService _recommendationService;

    public RecommendationPlugin(RecommendationService recommendationService)
    {
        _recommendationService = recommendationService;
    }

    [KernelFunction]
    public async Task<string> RecommendAccessories()
    {
        var response = await _recommendationService.GetRecommendations();

        if (response == null)
            return "No recommendations available.";

        return string.Join(", ", response.Products);
    }
}