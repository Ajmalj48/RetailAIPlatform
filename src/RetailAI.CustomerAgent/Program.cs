using RetailAI.CustomerAgent.Agents;
using RetailAI.CustomerAgent.Models;
using RetailAI.CustomerAgent.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();

builder.Services.AddScoped<KernelService>();

builder.Services.AddHttpClient<InventoryApiClient>();
builder.Services.AddHttpClient<ShippingApiClient>();
builder.Services.AddHttpClient<RecommendationApiClient>();

builder.Services.AddScoped<CustomerAgent>();

var app = builder.Build();

app.MapGet("/", () =>
{
    return "Customer Agent Running";
});

app.MapPost("/chat",
async (
ChatRequest request,
CustomerAgent customerAgent) =>
{
    var response =
        await customerAgent.ProcessRequest(
            request.UserMessage,
            "Kerala");

    return new ChatResponse
    {
        Response = response
    };
});

app.Run();