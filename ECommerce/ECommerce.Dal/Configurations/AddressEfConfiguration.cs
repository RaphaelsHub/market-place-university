using System.Data.Entity.ModelConfiguration;
using ECommerce.Core.Entities.User;

namespace ECommerce.Dal.Configurations
{
    public class AddressEfConfiguration: EntityTypeConfiguration<AddressEf>
    {
        #region Configuring the AddressEf entity.
        
        public AddressEfConfiguration()
        {
            ToTable("Addresses");
            HasKey(x => x.AddressId);
            HasRequired(x => x.User).WithMany(x => x.Addresses)
                .HasForeignKey(x => x.UserId);
        }

        #endregion
    }
}