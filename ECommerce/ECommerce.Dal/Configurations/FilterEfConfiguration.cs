using System.Data.Entity.ModelConfiguration;
using WebProject.Core.Entities.Product;

namespace WebProject.Dal.Configurations
{
    public class FilterEfConfiguration : EntityTypeConfiguration<FilterEf>
    {
        #region Configuring the FilterEf entity.
        
        public FilterEfConfiguration()
        {
            ToTable("Filters");

            HasKey(x => x.FilterId);

            HasRequired(x => x.Category).WithMany(x => x.Filters)
                .HasForeignKey(x => x.CategoryId);

            HasMany(x => x.FilterValues).WithRequired(x => x.Filter)
                .HasForeignKey(x => x.FilterId);
        }
        
        #endregion
    }
}