using System;
using ECommerce.Core.Models.DTOs.Contact;

namespace ECommerce.Core.Entities.User
{
    /// <summary>
    /// ContactUsEf entity, which is used to store the contact us form data in the database.
    /// </summary>
    public class ContactUsEf
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Subject { get; private set; }
        public string Message { get; private set; }
        public DateTime DateTime { get; private set; }

        public ContactUsEf() { }
        public ContactUsEf(ContactUsDto contactUsDto)
        {
            if (contactUsDto == null) return;
            
            Name = contactUsDto.Name;
            Email = contactUsDto.Email;
            PhoneNumber = contactUsDto.PhoneNumber;
            Subject = contactUsDto.Subject;
            Message = contactUsDto.Message;
            DateTime = DateTime.Now;
        }
    }
}