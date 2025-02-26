using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using ECommerce.Core.Entities.Blog;
using ECommerce.Core.Interfaces.Blog;

namespace ECommerce.Dal.Repositories.Blog
{
    public class MessagesRepository : IMessagesRepository
    {
        private readonly StoreContext _context;

        public MessagesRepository(StoreContext context) =>
            _context = context;

        public async Task<List<MessageEf>> GetMessagesByIdAsync(int idBlog)
        {
            var result = await _context.Blogs.Include(x => x.Comments).FirstOrDefaultAsync(x => x.BlogId == idBlog);
            return result?.Comments;
        }

        public async Task<MessageEf> AddMessageAsync(int idBlog, MessageEf message)
        {
            var result = await _context.Blogs.FirstOrDefaultAsync(x => x.BlogId == idBlog);
            result?.Comments.Add(message);
            await _context.SaveChangesAsync();
            return message;
        }

        public async Task<bool> DeleteMessageByIdAsync(int idBlog, int idMessage)
        {
            var result = await _context.Blogs.Include(x => x.Comments).FirstOrDefaultAsync(x => x.BlogId == idBlog);
            var message = result?.Comments.Find(x => x.MessageId == idMessage);
            if (message == null) return false;
            result.Comments.Remove(message);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}