using WebProject.Core.Entities.Blog;

namespace WebProject.Core.Interfaces.Blog
{
    public interface IMessagesRepository<T> : IGenericRepository<MessageEf>
    {
        
    }
}