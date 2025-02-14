using System;
using System.Threading.Tasks;
using ECommerce.App.Interfaces.User;
using ECommerce.Core.DataTransferObjects.Responses;
using ECommerce.Core.DataTransferObjects.User;
using ECommerce.Core.Entities.User;
using ECommerce.Core.Enums.Operation;
using ECommerce.Core.Interfaces.User;

namespace ECommerce.App.Services.User
{
    public class ContactUsService : IContactUsService
    {
        private readonly IContactUsRepository _contactUsRepository;
        
        public ContactUsService(IContactUsRepository contactUsRepository) => 
            _contactUsRepository = contactUsRepository;
        
        public async Task<MessageResponseDto> SendContactUsRequestAsync(ContactUsDto contactUsDto)
        {
            var contactUsEntity = new ContactUsEf()
            {
                Email = contactUsDto.Email,
                Message = contactUsDto.Message,
                Name = contactUsDto.Name,
                Subject = contactUsDto.Subject,
                PhoneNumber = contactUsDto.PhoneNumber,
                CreatedRequest = DateTime.UtcNow
            };

            await _contactUsRepository.CreateAsync(contactUsEntity);

            return new MessageResponseDto(0, "Your message has been sent successfully", RequestStatus.Success);
        }
    }
}