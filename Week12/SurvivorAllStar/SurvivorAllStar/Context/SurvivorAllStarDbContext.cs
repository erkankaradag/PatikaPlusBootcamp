using Microsoft.EntityFrameworkCore;
using SurvivorAllStar.Entity;

namespace SurvivorAllStar.Context
{
    public class SurvivorAllStarDbContext : DbContext
    {
        public SurvivorAllStarDbContext(DbContextOptions<SurvivorAllStarDbContext> options) : base(options) { }

        public DbSet<CategoryEntity> Categories => Set<CategoryEntity>();
        public DbSet<CompetitorEntity> Competitors => Set<CompetitorEntity>();
    }
}
