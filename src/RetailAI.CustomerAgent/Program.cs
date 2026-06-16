using RetailAI.CustomerAgent.Hubs;
using RetailAI.CustomerAgent.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();

builder.Services.AddSignalR();

builder.Services.AddSingleton<InventoryService>();

builder.Services.AddSingleton<ShippingService>();

builder.Services.AddSingleton<RecommendationService>();

var app = builder.Build();

app.MapHub<AgentHub>("/agentHub");