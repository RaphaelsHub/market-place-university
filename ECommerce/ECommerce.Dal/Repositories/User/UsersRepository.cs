using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Core.Entities.User;
using ECommerce.Core.Interfaces.User;

namespace ECommerce.Dal.Repositories.User
{
    public class UsersRepository : IUsersRepository
    {
        private readonly StoreContext _context;
        
        public UsersRepository(StoreContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<UserEf>> GetAllAsync() => 
            await _context.Users.ToListAsync();

        public async Task<UserEf> GetByIdAsync(int id) => 
            await _context.Users.FirstOrDefaultAsync(x => x.UserId == id);
        
        public async Task<UserEf> GetByEmailAsync(string email) => 
            await _context.Users.FirstOrDefaultAsync(x => x.Email == email);

        public async Task CreateAsync(UserEf entity)
        {
            _context.Users.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UserEf entity)
        {
            _context.Users.Attach(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserId == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

    }
}