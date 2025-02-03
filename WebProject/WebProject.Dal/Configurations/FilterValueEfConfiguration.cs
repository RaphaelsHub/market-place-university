using System.Data.Entity.ModelConfiguration;
using WebProject.Core.Entities.Product;

namespace WebProject.Dal.Configurations
{
    public class FilterValueEfConfiguration : EntityTypeConfiguration<FilterValueEf>
    {
        #region Configuring the FilterValueEf entity.

        public FilterValueEfConfiguration()
        {
            ToTable("FilterValues");

            HasKey(x => x.FilterValueId);

            HasRequired(x => x.Filter).WithMany(x => x.FilterValues)
                .HasForeignKey(x => x.FilterId);
        }

        #endregion
    }
}