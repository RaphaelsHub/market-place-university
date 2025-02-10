using System.Data.Entity.ModelConfiguration;
using WebProject.Core.Entities.Product;

namespace WebProject.Dal.Configurations
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