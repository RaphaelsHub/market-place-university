using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using ECommerce.Core.Entities.User;
using ECommerce.Core.Interfaces.User;

namespace ECommerce.Dal.Repositories.User
{
    public class ContactUsRepository : IContactUsRepository<ContactUsEf>
    {
        private readonly StoreContext _context;

        public ContactUsRepository(StoreContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<ContactUsEf>> GetAllAsync() =>
            await _context.ContactUs.ToListAsync();

        public async Task<ContactUsEf> GetByIdAsync(int id) =>
            await _context.ContactUs.FirstOrDefaultAsync(x => x.Id == id);

        public async Task CreateAsync(ContactUsEf entity)
        {
            _context.ContactUs.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ContactUsEf entity)
        {
            _context.ContactUs.Attach(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var contactUs = await _context.ContactUs.FirstOrDefaultAsync(x => x.Id == id);
            if (contactUs != null)
            {
                _context.ContactUs.Remove(contactUs);
                await _context.SaveChangesAsync();
            }
        }
    }
}