using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingApp.Data.Enums;
using ShoppingApp.Data.Enums;

namespace ShoppingApp.Data.Entities
{
    public class UserEntity : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public UserType UserType { get; set; }

        // Relation Property
        public ICollection<OrderEntity> Orders { get; set; }
    }

    public class UserConfiguration : BaseConfiguration<UserEntity>
    {
        public override void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            base.Configure(builder);
        }
    }
}