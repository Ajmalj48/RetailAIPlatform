using Microsoft.SemanticKernel;
using RetailAI.InventoryAgent.Tools;
using RetailAI.ShippingAgent.Tools;
using RetailAI.RecommendationAgent.Tools;

namespace RetailAI.CustomerAgent.Services;

public class KernelService
{
    private readonly IConfiguration _configuration;

    public KernelService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public Kernel CreateKernel(
        InventoryTool inventoryTool,
        ShippingTool shippingTool,
        RecommendationTool recommendationTool)
    {
        var endpoint =
            _configuration["Ollama:Endpoint"];

        var model =
            _configuration["Ollama:Model"];

        var builder = Kernel.CreateBuilder();

        builder.AddOpenAIChatCompletion(
            modelId: model!,
            endpoint: new Uri(endpoint!),
            apiKey: "ollama");

        var kernel = builder.Build();

        kernel.Plugins.AddFromObject(
            inventoryTool,
            "Inventory");

        kernel.Plugins.AddFromObject(
            shippingTool,
            "Shipping");

        kernel.Plugins.AddFromObject(
            recommendationTool,
            "Recommendation");

        return kernel;
    }
}