using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.Core.Entities.Blog;

namespace ECommerce.Core.Interfaces.Blog
{
    public interface IMessagesRepository
    {
        Task<List<MessageEf>> GetMessagesByIdAsync(int idBlog);
        Task<MessageEf> AddMessageAsync(int idBlog, MessageEf message);
        Task<bool> DeleteMessageByIdAsync(int idBlog, int idMessage);
    }
}