using Microsoft.EntityFrameworkCore;
using RetailAI.RecommendationAgent.Data;

namespace RetailAI.RecommendationAgent.Services;

public class RecommendationService
{
    private readonly RecommendationDbContext _db;

    public RecommendationService(
        RecommendationDbContext db)
    {
        _db = db;
    }

    public async Task<List<string>> GetRecommendations(
        string product)
    {
        return await _db.RecommendationMappings
            .Where(x => x.ProductName.Contains(product))
            .Select(x => x.RecommendedProduct)
            .ToListAsync();
    }
}