using CodeFirstRelation.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;


namespace CodeFirstRelation.Context
{
    public class PatikaSecondDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<PostEntity> Posts { get; set; }

        protected override void OnConfiguring
            (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=HURGENC\SQLEXPRESS;Database=PatikaCodeFirstDb2;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User-Post Relationship
            modelBuilder.Entity<PostEntity>()
                .HasOne(p => p.User)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.UserId);
        }

    }
}
