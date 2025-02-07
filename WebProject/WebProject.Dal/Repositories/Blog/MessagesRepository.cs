using System.Collections.Generic;
using System.Threading.Tasks;
using WebProject.Core.Entities.Blog;
using WebProject.Core.Interfaces.Blog;

namespace WebProject.Dal.Repositories.Blog
{
    public class MessagesRepository : IMessagesRepository<MessageEf>
    {
        private readonly StoreContext _context;

        public MessagesRepository(StoreContext context)
        {
            _context = context;
        }
        
        public Task<IEnumerable<MessageEf>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<MessageEf> GetByIdAsync(uint id)
        {
            throw new System.NotImplementedException();
        }

        public Task AddAsync(MessageEf entity)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(MessageEf entity)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteByIdAsync(uint id)
        {
            throw new System.NotImplementedException();
        }
    }
}