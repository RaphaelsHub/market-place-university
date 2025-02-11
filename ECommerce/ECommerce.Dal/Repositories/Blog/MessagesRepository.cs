using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using ECommerce.Core.Entities.Blog;
using ECommerce.Core.Interfaces.Blog;

namespace ECommerce.Dal.Repositories.Blog
{
    public class MessagesRepository : IMessagesRepository<MessageEf>
    {
        private readonly StoreContext _context;

        public MessagesRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MessageEf>> GetAllAsync() =>
            await _context.Messages.ToListAsync();

        public async Task<MessageEf> GetByIdAsync(int id) =>
            await _context.Messages.FirstOrDefaultAsync(x => x.MessageId == id);

        public async Task CreateAsync(MessageEf entity)
        {
            _context.Messages.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(MessageEf entity)
        {
            _context.Messages.Attach(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var message = await _context.Messages.FirstOrDefaultAsync(x => x.MessageId == id);
            if (message != null)
            {
                _context.Messages.Remove(message);
                await _context.SaveChangesAsync();
            }
        }
    }
}