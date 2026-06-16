using RetailAI.Shared.Models;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/inventory/check", (string product) =>
{
    return new InventoryResponse
    {
        Available = true,
        Quantity = 15,
        Product = product
    };
});

app.Run();