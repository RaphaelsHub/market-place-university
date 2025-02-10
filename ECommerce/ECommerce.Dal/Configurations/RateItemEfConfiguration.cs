using System.Data.Entity.ModelConfiguration;
using ECommerce.Core.Entities.Product;

namespace ECommerce.Dal.Configurations
{
    public class RateItemEfConfiguration : EntityTypeConfiguration<RateItemEf>
    {
        #region Configuring the RateItemEf entity.
        
        public RateItemEfConfiguration()
        {
            ToTable("RateItems");

            HasKey(x => x.RateItemId);

            HasRequired(x => x.Product)
                .WithMany(x => x.RateItems)
                .HasForeignKey(x => x.ProductId);
        }
        
        #endregion
    }
}