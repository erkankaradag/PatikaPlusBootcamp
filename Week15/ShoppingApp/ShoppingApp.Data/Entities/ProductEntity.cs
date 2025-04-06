using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShoppingApp.Data.Entities
{
    public class ProductEntity : BaseEntity
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }

        // Relation Property
        public ICollection<OrderProductEntity> OrderProducts { get; set; }
    }

    public class ProdurctConfiguration : BaseConfiguration<ProductEntity>
    {
        public override void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            base.Configure(builder);
            // Precision ayarı burada yapılmalı
            builder.Property(p => p.Price) //-----------------------
                   .HasPrecision(18, 2);
        }
    }
}