using System.Data.Entity.ModelConfiguration;
using ECommerce.Core.Entities.Blog;

namespace ECommerce.Dal.Configurations
{
    public class MessageEfConfiguration : EntityTypeConfiguration<MessageEf>
    {
        #region Configuring the MessageEf entity.
        
        public MessageEfConfiguration()
        {
            ToTable("Messages");
            HasKey(x => x.MessageId);
            HasRequired(x => x.Blog).WithMany(x => x.Comments).HasForeignKey(x => x.BlogId);
            HasRequired(x => x.Sender).WithMany().HasForeignKey(x => x.UserSenderId);
            HasOptional(x => x.UserReceiver).WithMany().HasForeignKey(x => x.UserReceiverId);
        }

        #endregion
    }
}