using System.Data.Entity.ModelConfiguration;
using WebProject.Core.Entities.User;

namespace WebProject.Dal.Configurations
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