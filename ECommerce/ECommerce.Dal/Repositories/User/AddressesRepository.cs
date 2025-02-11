using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using ECommerce.Core.Entities.User;
using ECommerce.Core.Interfaces.User;

namespace ECommerce.Dal.Repositories.User
{
    public class AddressesRepository : IAddressesRepository<AddressEf>
    {
        private readonly StoreContext _context;

        public AddressesRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AddressEf>> GetAllAsync() =>
            await _context.Addresses.ToListAsync();

        public async Task<AddressEf> GetByIdAsync(int id) =>
            await _context.Addresses.FirstOrDefaultAsync(x => x.AddressId == id);

        public async Task CreateAsync(AddressEf entity)
        {
            _context.Addresses.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(AddressEf entity)
        {
            _context.Addresses.Attach(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var address = await _context.Addresses.FirstOrDefaultAsync(x => x.AddressId == id);
            if (address != null)
            {
                _context.Addresses.Remove(address);
                await _context.SaveChangesAsync();
            }
        }
    }
}