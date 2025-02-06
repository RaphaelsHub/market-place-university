using System.Data.Entity.ModelConfiguration;
using WebProject.Core.Entities.User;

namespace WebProject.Dal.Configurations
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

            HasMany(x => x.CartItems).WithRequired(x => x.User).HasForeignKey(x=>x.UserId);

            #endregion
        }
    }
}