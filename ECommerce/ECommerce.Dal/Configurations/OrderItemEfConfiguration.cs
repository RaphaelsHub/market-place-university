using System.Data.Entity.ModelConfiguration;
using WebProject.Core.Entities.User;

namespace WebProject.Dal.Configurations
{
    public class OrderItemEfConfiguration : EntityTypeConfiguration<OrderItemEf>
    {
        #region Configuring the OrderItemEf entity.
        
        public OrderItemEfConfiguration()
        {
            ToTable("OrderItems");
            HasKey(x => x.OrderItemId);

            HasRequired(x => x.Product).WithMany().HasForeignKey(x => x.ProductId);

            HasRequired(x => x.Order).WithMany(x => x.OrderItems)
                .HasForeignKey(x => x.OrderId);

            HasRequired(x => x.User).WithMany().HasForeignKey(x => x.UserId);
        }

        #endregion
    }
}