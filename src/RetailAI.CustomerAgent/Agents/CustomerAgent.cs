using Microsoft.SemanticKernel;

namespace RetailAI.CustomerAgent.Agents;

public class CustomerAgent
{
    private readonly Kernel _kernel;

    public CustomerAgent(Kernel kernel)
    {
        _kernel = kernel;
    }

    public async Task<string> ProcessRequestAsync(
        string userRequest)
    {
        var prompt = $$$"""
You are an AI Shopping Assistant.

User request:

{{userRequest}}

Use the available tools to answer.

You may need:

InventoryTool
ShippingTool
RecommendationTool

Generate a helpful response.
""";

        var response =
            await _kernel.InvokePromptAsync(prompt);

        return response.ToString();
    }
}