using Microsoft.EntityFrameworkCore;
using ShoppingApp.Data.Entities;
using ShoppingApp.Data.Entities;

namespace ShoppingApp.Data.Context
{
    public class ShoppingAppDbContext : DbContext
    {
        public ShoppingAppDbContext(DbContextOptions<ShoppingAppDbContext> options) : base(options)
        {

        }


        // What I did is call the rules to the db. Fluent Api
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new ProdurctConfiguration());
            modelBuilder.ApplyConfiguration(new OrderProductConfiguration());


            modelBuilder.Entity<SettingEntity>().HasData(new SettingEntity
            {
                Id = 1,
                MaintenenceMode = false
            });

            base.OnModelCreating(modelBuilder);
        }


        public DbSet<UserEntity> Users => Set<UserEntity>();
        public DbSet<OrderEntity> Orders => Set<OrderEntity>();
        public DbSet<ProductEntity> Products => Set<ProductEntity>();
        public DbSet<OrderProductEntity> OrderProducts => Set<OrderProductEntity>();
        public DbSet<SettingEntity> Settings { get; set; }
    }
}