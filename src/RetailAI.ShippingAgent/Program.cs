using Microsoft.EntityFrameworkCore;
using RetailAI.ShippingAgent.Data;
using RetailAI.ShippingAgent.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ShippingDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<ShippingService>();

var app = builder.Build();

app.MapGet("/", () => "Shipping Agent Running");

app.MapGet("/shipping/estimate",
async (
string region,
ShippingService shippingService) =>
{
    var shippingInfo =
        await shippingService.GetShippingInfo(region);

    if (shippingInfo == null)
    {
        return Results.NotFound("Region not found");
    }

    return Results.Ok(shippingInfo);
});

app.Run();