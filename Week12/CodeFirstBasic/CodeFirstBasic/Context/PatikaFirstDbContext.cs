using CodeFirstBasic.Entities.Game;
using CodeFirstBasic.Entities.Movie;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstBasic.Context
{
    public class PatikaFirstDbContext : DbContext
    {
        public DbSet<GameEntity> GameEntities { get; set; }
        public DbSet<MovieEntity> MovieEntities { get; set; }
        protected override void OnConfiguring
            (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=HURGENC\SQLEXPRESS;Database=PatikaCodeFirstDb1;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        public DbSet<GameEntity> Games => Set<GameEntity>();
        public DbSet<MovieEntity> Movies => Set<MovieEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieEntity>().ToTable("Movies");
            modelBuilder.Entity<GameEntity>().ToTable("Games");
            modelBuilder.Entity<GameEntity>()
                .Property(g => g.Rating)
                .HasPrecision(3, 1); // Örneğin: 7.5, 9.8 gibi değerleri destekler.

            base.OnModelCreating(modelBuilder);

        }
    }
}
