using RetailAI.Shared.Models;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/shipping/estimate", () =>
{
    return new ShippingResponse
    {
        DeliveryDays = 2
    };
});

app.Run();