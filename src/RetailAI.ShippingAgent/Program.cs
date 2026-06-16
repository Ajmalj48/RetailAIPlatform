using Microsoft.EntityFrameworkCore;
using RetailAI.ShippingAgent.Data;
using RetailAI.ShippingAgent.Services;
using RetailAI.ShippingAgent.Tools;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ShippingDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString(
            "DefaultConnection"));
});

builder.Services.AddScoped<ShippingService>();

builder.Services.AddScoped<ShippingTool>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () =>
{
    return "Shipping Agent Running";
});

app.Run();