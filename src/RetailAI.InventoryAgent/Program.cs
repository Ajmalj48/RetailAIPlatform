using Microsoft.EntityFrameworkCore;
using RetailAI.InventoryAgent.Data;
using RetailAI.InventoryAgent.Services;
using RetailAI.InventoryAgent.Tools;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<InventoryDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString(
            "DefaultConnection"));
});

builder.Services.AddScoped<InventoryService>();

builder.Services.AddScoped<InventoryTool>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () =>
{
    return "Inventory Agent Running";
});

app.Run();