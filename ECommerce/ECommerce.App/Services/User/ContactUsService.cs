using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.App.Interfaces.User;
using ECommerce.Core.Entities.User;
using ECommerce.Core.Enums.Request;
using ECommerce.Core.Interfaces.User;
using ECommerce.Core.Models.DTOs.Contact;
using ECommerce.Core.Models.DTOs.GenericResponses;
using ECommerce.Core.Models.ViewModels;
using ExpressMapper;

namespace ECommerce.App.Services.User
{
    public class ContactUsService : IContactUsService
    {
        private readonly IContactUsRepository _contactUsRepository;
        
        public ContactUsService(IContactUsRepository contactUsRepository) => 
            _contactUsRepository = contactUsRepository;

        public async Task<BaseResponse<List<ContactUsDto>>> GetContactUsRequestsAsync(string email, int page, int pageSize)
        {
           var listOfContactUsEfs = await _contactUsRepository.GetAllContactUsRequestsAsync(email, page, pageSize);

           var listOfContactUsDtos = listOfContactUsEfs.Select(Mapper.Map<ContactUsEf, ContactUsDto>).ToList();
           
           return new BaseResponse<List<ContactUsDto>>(listOfContactUsDtos, OperationStatus.Success, "List of contact us requests");
        }

        public async Task<BaseResponse<bool>> DeleteContactUsRequestByIdAsync(int id)
        {
            var response = await _contactUsRepository.DeleteContactUsRequestAsync(id);
            return new BaseResponse<bool>(response, OperationStatus.Success, "Contact us request has been deleted successfully or not found");
        }

        public async Task<ConfirmationViewModel> CreateContactUsRequestAsync(ContactUsDto contactUsDto)
        {
            contactUsDto.DateTime = DateTime.UtcNow;
            
            var contactUsEf = Mapper.Map<ContactUsDto, ContactUsEf>(contactUsDto);
            
            var returnedContactUsEf = await _contactUsRepository.AddContactUsRequestAsync(contactUsEf);
            
            return returnedContactUsEf != null 
                ? new ConfirmationViewModel(OperationStatus.Success, "Your message has been sent successfully") 
                : new ConfirmationViewModel(OperationStatus.Error, "An error occurred while sending your message");
        }
    }
}