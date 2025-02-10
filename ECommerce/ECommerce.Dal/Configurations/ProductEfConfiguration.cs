using System.Data.Entity.ModelConfiguration;
using ECommerce.Core.Entities.Product;

namespace ECommerce.Dal.Configurations
{
    public class ProductEfConfiguration : EntityTypeConfiguration<ProductEf>
    {
        #region Configuring the ProductEf entity.

        public ProductEfConfiguration()
        {
            ToTable("Products");
            
            HasKey(x => x.ProductId);
            
            HasRequired(x => x.Category).WithMany().HasForeignKey(x => x.CategoryId);
            
            HasMany(x => x.RateItems).WithRequired(x => x.Product).HasForeignKey(x => x.ProductId);
        }

        #endregion
    }
}