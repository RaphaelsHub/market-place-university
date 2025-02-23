using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Core.Entities.User;
using ECommerce.Core.Interfaces.User;

namespace ECommerce.Dal.Repositories.User
{
    public class ContactUsRepository : IContactUsRepository
    {
        private readonly StoreContext _context;

        public ContactUsRepository(StoreContext context)=>
            _context = context;
        
        public Task<List<ContactUsEf>> GetAllContactUsRequestsAsync(string email, int page, int pageSize)
        {
            var list = _context.ContactUs.AsQueryable();
            if(!string.IsNullOrEmpty(email)) list = list.Where(x => x.Email.Contains(email));
            return list.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<ContactUsEf> AddContactUsRequestAsync(ContactUsEf contactUsEntity)
        {
            _context.ContactUs.Add(contactUsEntity);
            await _context.SaveChangesAsync();
            return contactUsEntity;
        }

        public async Task<bool> DeleteContactUsRequestAsync(int id)
        {
            var contactUs = await _context.ContactUs.FirstOrDefaultAsync(x => x.Id == id);

            if (contactUs != null)
            {
                _context.ContactUs.Remove(contactUs);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}