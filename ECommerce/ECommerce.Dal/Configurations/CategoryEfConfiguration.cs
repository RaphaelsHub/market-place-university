using System.Data.Entity.ModelConfiguration;
using ECommerce.Core.Entities.Product;

namespace ECommerce.Dal.Configurations
{
    public class CategoryEfConfiguration : EntityTypeConfiguration<CategoryEf>
    {
        #region Configuring the CategoryEf entity.
        
        public CategoryEfConfiguration()
        {
            ToTable("Categories");

            HasKey(x => x.CategoryId);

            HasMany(x => x.Filters).WithRequired(x => x.Category)
                .HasForeignKey(x => x.CategoryId);
        }
        
        #endregion
    }
}