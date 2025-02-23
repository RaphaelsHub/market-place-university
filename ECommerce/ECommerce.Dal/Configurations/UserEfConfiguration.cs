using System.Data.Entity.ModelConfiguration;
using ECommerce.Core.Entities.User;

namespace ECommerce.Dal.Configurations
{
    public class UserEfConfiguration : EntityTypeConfiguration<UserEf>
    {
        public UserEfConfiguration()
        {
            #region Configuring the UserEf entity.

            ToTable("Users");
            HasKey(x => x.UserId);

            HasMany(x => x.Addresses).WithRequired(x => x.User).HasForeignKey(x=>x.UserId).WillCascadeOnDelete(false);

            HasMany(x => x.Orders).WithRequired(x => x.User).HasForeignKey(x=>x.UserId).WillCascadeOnDelete(false);

            HasMany(x => x.Cart).WithRequired(x => x.User).HasForeignKey(x=>x.UserId);

            #endregion
        }
    }
}