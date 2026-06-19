using Microsoft.EntityFrameworkCore;
using RetailAI.RecommendationAgent.Models;

namespace RetailAI.RecommendationAgent.Data;

public class RecommendationDbContext : DbContext
{
    public RecommendationDbContext(
        DbContextOptions<RecommendationDbContext> options)
        : base(options)
    {
    }

    public DbSet<RecommendationMapping>
        RecommendationMappings =>
        Set<RecommendationMapping>();
}