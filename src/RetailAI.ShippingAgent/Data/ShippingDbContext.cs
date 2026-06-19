using Microsoft.EntityFrameworkCore;
using RetailAI.ShippingAgent.Models;

namespace RetailAI.ShippingAgent.Data;

public class ShippingDbContext : DbContext
{
    public ShippingDbContext(
        DbContextOptions<ShippingDbContext> options)
        : base(options)
    {
    }

    public DbSet<ShippingRegion> ShippingRegions =>
        Set<ShippingRegion>();
}