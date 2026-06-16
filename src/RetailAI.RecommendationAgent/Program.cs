using RetailAI.Shared.Models;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/recommendations", () =>
{
    return new RecommendationResponse
    {
        Products =
        [
            "Wireless Mouse",
            "Laptop Bag",
            "USB-C Hub"
        ]
    };
});

app.Run();