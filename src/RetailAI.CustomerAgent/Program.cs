using RetailAI.CustomerAgent.Agents;
using RetailAI.CustomerAgent.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();

builder.Services.AddScoped<KernelService>();

builder.Services.AddScoped<InventoryApiClient>();
builder.Services.AddScoped<ShippingApiClient>();
builder.Services.AddScoped<RecommendationApiClient>();

builder.Services.AddScoped<CustomerAgent>();

var app = builder.Build();

app.MapGet("/", () => "Customer Agent Running");

app.Run();