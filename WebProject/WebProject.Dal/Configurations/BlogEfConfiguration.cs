using System.Data.Entity.ModelConfiguration;
using WebProject.Core.Entities.Blog;

namespace WebProject.Dal.Configurations
{
    public class BlogEfConfiguration : EntityTypeConfiguration<BlogEf>
    {
        #region Configuring the BlogEf entity.
        
        public BlogEfConfiguration()
        {
            ToTable("Blogs");
            HasKey(x => x.BlogId);
            HasMany(x => x.Comments).WithRequired(x => x.Blog).HasForeignKey(x => x.BlogId);
        }
        
        #endregion
    }
}