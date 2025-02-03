using System.Data.Entity.ModelConfiguration;
using WebProject.Core.Entities.User;

namespace WebProject.Dal.Configurations
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