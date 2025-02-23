using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.Core.Models.DTOs.Contact;
using ECommerce.Core.Models.DTOs.GenericResponses;
using ECommerce.Core.Models.ViewModels;

namespace ECommerce.App.Interfaces.User
{
    public interface IContactUsService
    {
        Task<ConfirmationViewModel> CreateContactUsRequestAsync(ContactUsDto contactUsDto);
        Task<BaseResponse<bool>> DeleteContactUsRequestByIdAsync(int id);
        Task<BaseResponse<List<ContactUsDto>>> GetContactUsRequestsAsync(string email, int page, int pageSize);

    }
}