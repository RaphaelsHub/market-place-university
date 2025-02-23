using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.Core.Entities.User;

namespace ECommerce.Core.Interfaces.User
{
    public interface IContactUsRepository
    {
        Task<List<ContactUsEf>> GetAllContactUsRequestsAsync(string email, int page, int pageSize);
        Task<ContactUsEf> AddContactUsRequestAsync(ContactUsEf contactUsEntity);
        Task<bool> DeleteContactUsRequestAsync(int id);
    }
}