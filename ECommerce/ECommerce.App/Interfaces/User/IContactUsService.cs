using System.Threading.Tasks;
using ECommerce.Core.Models;
using ECommerce.Core.Models.DTOs.ContactUs;
using ECommerce.Core.Models.ViewModels;

namespace ECommerce.App.Interfaces.User
{
    public interface IContactUsService
    {
        Task<MessageViewModel> SendContactUsRequestAsync(ContactUsDto contactUsDto);
    }
}