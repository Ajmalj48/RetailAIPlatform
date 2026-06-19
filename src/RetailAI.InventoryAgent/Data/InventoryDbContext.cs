using Microsoft.EntityFrameworkCore;
using RetailAI.InventoryAgent.Models;

namespace RetailAI.InventoryAgent.Data;

public class InventoryDbContext : DbContext
{
    public InventoryDbContext(
        DbContextOptions<InventoryDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();
}