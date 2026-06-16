using Microsoft.EntityFrameworkCore;
using RetailAI.RecommendationAgent.Data;
using RetailAI.RecommendationAgent.Services;
using RetailAI.RecommendationAgent.Tools;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RecommendationDbContext>(
options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString(
            "DefaultConnection"));
});

builder.Services.AddScoped<RecommendationService>();

builder.Services.AddScoped<RecommendationTool>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () =>
{
    return "Recommendation Agent Running";
});

app.Run();