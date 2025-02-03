using System.Data.Entity.ModelConfiguration;
using WebProject.Core.Entities.Product;

namespace WebProject.Dal.Configurations
{
    public class CategoryEfConfiguration : EntityTypeConfiguration<CategoryEf>
    {
        #region Configuring the CategoryEf entity.
        
        public CategoryEfConfiguration()
        {
            ToTable("Categories");

            HasKey(x => x.ParentCategoryId);

            HasMany(x => x.Filters).WithRequired(x => x.Category)
                .HasForeignKey(x => x.CategoryId);
        }
        
        #endregion
    }
}