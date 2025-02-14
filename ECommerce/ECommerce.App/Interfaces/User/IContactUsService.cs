using System.Threading.Tasks;
using ECommerce.Core.DataTransferObjects.Responses;
using ECommerce.Core.DataTransferObjects.User;

namespace ECommerce.App.Interfaces.User
{
    public interface IContactUsService
    {
        Task<MessageResponseDto> SendContactUsRequestAsync(ContactUsDto contactUsDto);
    }
}