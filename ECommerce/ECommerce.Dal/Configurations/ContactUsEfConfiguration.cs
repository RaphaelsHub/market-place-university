using System.Data.Entity.ModelConfiguration;
using ECommerce.Core.Entities.User;

namespace ECommerce.Dal.Configurations
{
    public class ContactUsEfConfiguration : EntityTypeConfiguration<ContactUsEf>
    {
        public ContactUsEfConfiguration()
        {
            ToTable("ContactUs");
            
            HasKey(x => x.Id);
        }
    }
}