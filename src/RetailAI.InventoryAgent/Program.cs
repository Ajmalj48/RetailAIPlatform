using Microsoft.EntityFrameworkCore;
using RetailAI.InventoryAgent.Data;
using RetailAI.InventoryAgent.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<InventoryDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<InventoryService>();

var app = builder.Build();

app.MapGet("/", () => "Inventory Agent Running");

app.MapGet("/inventory/check",
async (
string product,
InventoryService inventoryService) =>
{
    var item =
        await inventoryService.FindProduct(product);

    if (item == null)
    {
        return Results.NotFound("Product not found");
    }

    return Results.Ok(item);
});

app.Run();