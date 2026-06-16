using Microsoft.EntityFrameworkCore;
using RetailAI.RecommendationAgent.Data;
using RetailAI.RecommendationAgent.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RecommendationDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<RecommendationService>();

var app = builder.Build();

app.MapGet("/", () => "Recommendation Agent Running");

app.MapGet("/recommendations",
async (
string product,
RecommendationService recommendationService) =>
{
    var recommendations =
        await recommendationService.GetRecommendations(product);

    return Results.Ok(recommendations);
});

app.Run();