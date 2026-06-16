using RetailAI.CustomerAgent.Agents;
using RetailAI.CustomerAgent.Services;
using RetailAI.InventoryAgent.Tools;
using RetailAI.ShippingAgent.Tools;
using RetailAI.RecommendationAgent.Tools;
using RetailAI.CustomerAgent.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<KernelService>();

builder.Services.AddScoped<InventoryTool>();
builder.Services.AddScoped<ShippingTool>();
builder.Services.AddScoped<RecommendationTool>();

builder.Services.AddSingleton(sp =>
{
    var service =
        sp.GetRequiredService<KernelService>();

    return service.CreateKernel(
        sp.GetRequiredService<InventoryTool>(),
        sp.GetRequiredService<ShippingTool>(),
        sp.GetRequiredService<RecommendationTool>());
});

builder.Services.AddSingleton<CustomerAgent>();

var app = builder.Build();

app.MapGet("/", () =>
{
    return "Customer Agent Running";
});

app.MapPost("/chat",
async (ChatRequest request,
CustomerAgent agent) =>
{
    var response =
        await agent.ProcessRequestAsync(
            request.UserMessage);

    return new ChatResponse
    {
        Response = response
    };
});

app.Run();