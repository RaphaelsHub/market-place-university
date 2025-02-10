using System.Data.Entity.ModelConfiguration;
using ECommerce.Core.Entities.User;

namespace ECommerce.Dal.Configurations
{
    public class CartItemEfConfiguration : EntityTypeConfiguration<CartItemEf>
    {
        #region Configuring the CartItemEf entity.

        public CartItemEfConfiguration()
        {
            ToTable("CartItems");

            HasKey(x => new { x.ProductId, x.UserId });

            HasRequired(x => x.Product).WithMany().HasForeignKey(x => x.ProductId);

            HasRequired(x => x.User).WithMany(x => x.CartItems)
                .HasForeignKey(x => x.UserId);
        }

        #endregion
    }
}