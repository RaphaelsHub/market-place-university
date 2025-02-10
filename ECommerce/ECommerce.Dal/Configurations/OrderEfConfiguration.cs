using System.Data.Entity.ModelConfiguration;
using ECommerce.Core.Entities.User;

namespace ECommerce.Dal.Configurations
{
    public class OrderEfConfiguration : EntityTypeConfiguration<OrderEf>
    {
        #region Configuring the OrderEf entity.
        
        public OrderEfConfiguration()
        {
            ToTable("Orders");
            HasKey(x => x.OrderId);

            HasRequired(x => x.User).WithMany(x => x.Orders)
                .HasForeignKey(x => x.UserId);

            HasRequired(x => x.Address).WithMany().HasForeignKey(x => x.AddressId);

            HasMany(x => x.OrderItems).WithRequired(x => x.Order)
                .HasForeignKey(x => x.OrderId);
        }
        
        #endregion
    }
}