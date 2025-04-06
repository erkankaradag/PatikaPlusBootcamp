using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShoppingApp.Data.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
    }

    // where TEntity = BaseEntity and entities inheriting from it
    public abstract class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        // General rules given
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            // All queries and connectors call those where IsDeleted == false.
            builder.HasQueryFilter(x => x.IsDeleted == false);

            // ModifiedDate == null. It does not have to be filled in.
            builder.Property(x => x.ModifiedDate).IsRequired(false);
        }
    }
}