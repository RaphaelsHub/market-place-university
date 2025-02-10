using System.Data.Entity.ModelConfiguration;
using ECommerce.Core.Entities.Product;

namespace ECommerce.Dal.Configurations
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