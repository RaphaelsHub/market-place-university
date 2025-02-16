using System;
using System.Threading.Tasks;
using ECommerce.App.Interfaces.User;
using ECommerce.Core.Entities.User;
using ECommerce.Core.Enums.Message;
using ECommerce.Core.Interfaces.User;
using ECommerce.Core.Models;
using ECommerce.Core.Models.DTOs.ContactUs;
using ECommerce.Core.Models.ViewModels;

namespace ECommerce.App.Services.User
{
    public class ContactUsService : IContactUsService
    {
        private readonly IContactUsRepository _contactUsRepository;
        
        public ContactUsService(IContactUsRepository contactUsRepository) => 
            _contactUsRepository = contactUsRepository;
        
        public async Task<MessageViewModel> SendContactUsRequestAsync(ContactUsDto contactUsDto)
        {
            var contactUsEntity = new ContactUsEf()
            {
                Email = contactUsDto.Email,
                Message = contactUsDto.Message,
                Name = contactUsDto.Name,
                Subject = contactUsDto.Subject,
                PhoneNumber = contactUsDto.PhoneNumber,
                DateTime = DateTime.UtcNow
            };

            await _contactUsRepository.CreateAsync(contactUsEntity);

            return new MessageViewModel(0, "Your message has been sent successfully", RequestStatus.Success);
        }
    }
}