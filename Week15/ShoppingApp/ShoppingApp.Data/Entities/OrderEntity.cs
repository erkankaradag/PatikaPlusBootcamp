using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingApp.Data.Entities;

namespace ShoppingApp.Data.Entities
{
    public class OrderEntity : BaseEntity
    {
        public decimal TotalAmount { get; set; }
        public int CustomerId { get; set; }

        // Relation Property
        [ForeignKey("CustomerId")]
        public UserEntity User { get; set; }

        public ICollection<OrderProductEntity> OrderProducts { get; set; }
    }

    public class OrderConfiguration : BaseConfiguration<OrderEntity>
    {
        public override void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            base.Configure(builder);
            // Precision ayarı ekleniyor
            builder.Property(o => o.TotalAmount) //---------------------
                   .HasPrecision(18, 2);
        }
    }
}