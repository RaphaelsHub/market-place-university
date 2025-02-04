using WebProject.Core.Entities.Blog;

namespace WebProject.Core.Interfaces.Blog
{
    public interface IBlogsRepository<T> : IGenericRepository<BlogEf>
    {
        
    }
}