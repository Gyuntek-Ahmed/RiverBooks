using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RiverBooks.Users.Data
{
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItems>
    {
        public void Configure(EntityTypeBuilder<CartItems> builder)
        {
            builder
                .Property(item => item.Id)
                .ValueGeneratedNever();
        }
    }
}
