using Microsoft.EntityFrameworkCore;
using RetailAI.InventoryAgent.Data;
using RetailAI.InventoryAgent.Models;

namespace RetailAI.InventoryAgent.Services;

public class InventoryService
{
    private readonly InventoryDbContext _db;

    public InventoryService(InventoryDbContext db)
    {
        _db = db;
    }

    public async Task<Product?> FindProduct(string productName)
    {
        return await _db.Products
            .FirstOrDefaultAsync(x =>
                x.Name.Contains(productName));
    }
}