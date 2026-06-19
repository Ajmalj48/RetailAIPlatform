using Microsoft.EntityFrameworkCore;
using RetailAI.ShippingAgent.Data;
using RetailAI.ShippingAgent.Models;

namespace RetailAI.ShippingAgent.Services;

public class ShippingService
{
    private readonly ShippingDbContext _db;

    public ShippingService(
        ShippingDbContext db)
    {
        _db = db;
    }

    public async Task<ShippingRegion?> GetShippingInfo(
        string region)
    {
        return await _db.ShippingRegions
            .FirstOrDefaultAsync(x =>
                x.Region.Contains(region));
    }
}