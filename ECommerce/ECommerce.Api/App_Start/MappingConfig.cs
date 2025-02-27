using ECommerce.Core.Entities.Blog;
using ECommerce.Core.Entities.Product;
using ECommerce.Core.Entities.User;
using ECommerce.Core.Enums.User;
using ECommerce.Core.Models.DTOs.Blog;
using ECommerce.Core.Models.DTOs.Contact;
using ECommerce.Core.Models.DTOs.Order;
using ECommerce.Core.Models.DTOs.Product;
using ECommerce.Core.Models.DTOs.User;
using ECommerce.Helper;
using ExpressMapper;

namespace ECommerce
{
    public class MappingConfig
    {
        public static void RegisterMappings()
        {
            RegisterProductMappings();
            RegisterUserMappings();
            RegisterContactUsMappings();
            RegisterBlogMappings();
            RegisterMessageMappings();
            RegisterAddressMappings();
        }

        private static void RegisterAddressMappings()
        {
            Mapper.Register<OrderDataDto, AddressEf>()
                .Member(dest => dest.FirstName, src => src.FirstName)
                .Member(dest => dest.LastName, src => src.LastName)
                .Member(dest => dest.Phone, src => src.PhoneNumber)
                .Member(dest => dest.Email, src => src.Email)
                .Member(dest => dest.Country, src => src.Country)
                .Member(dest => dest.City, src => src.City)
                .Member(dest => dest.Address1, src => src.Address1)
                .Member(dest => dest.Address2, src => src.Address2)
                .Member(dest => dest.PostalCode, src => src.PostalCode)
                .Member(dest => dest.OrderNote, src => src.OrderNote);
            
            Mapper.Register<AddressEf,OrderDataDto>()
                .Member(dest => dest.FirstName, src => src.FirstName)
                .Member(dest => dest.LastName, src => src.LastName)
                .Member(dest => dest.PhoneNumber, src => src.Phone)
                .Member( dest => dest.Email, src => src.Email)
                .Member(dest => dest.Country, src => src.Country)
                .Member(dest => dest.City, src => src.City)
                .Member(dest => dest.Address1, src => src.Address1)
                .Member(dest => dest.Address2, src => src.Address2)
                .Member(dest => dest.PostalCode, src => src.PostalCode)
                .Member(dest => dest.OrderNote, src => src.OrderNote);
            
            Mapper.Register<AddressEf,AddressEf>()
                .Member(dest => dest.FirstName, src => src.FirstName)
                .Member(dest => dest.LastName, src => src.LastName)
                .Member(dest => dest.Phone, src => src.Phone)
                .Member( dest => dest.Email, src => src.Email)
                .Member(dest => dest.Country, src => src.Country)
                .Member(dest => dest.City, src => src.City)
                .Member(dest => dest.Address1, src => src.Address1)
                .Member(dest => dest.Address2, src => src.Address2)
                .Member(dest => dest.PostalCode, src => src.PostalCode)
                .Member(dest => dest.OrderNote, src => src.OrderNote);
        }   

        private static void RegisterMessageMappings()
        {
            Mapper.Register<MessageDto, MessageEf>()
                .Member(dest => dest.Content, src => src.Content)
                .Member(dest => dest.IsReplied, src => src.IsReplied)
                .Member(dest=>dest.BlogId, src=>src.BlogId)
                .Member(dest => dest.UserSenderId, src => src.UserSenderId)
                .Member(dest => dest.UserReceiverId, src => src.UserReceiverId);
                
            Mapper.Register<MessageEf, MessageDto>()
                .Member(dest=>dest.MessageId, src=>src.MessageId)
                .Member(dest => dest.Content, src => src.Content)
                .Member(dest => dest.DateSent, src => src.DateSent)
                .Member(dest => dest.Status, src => src.Status)
                .Member(dest => dest.IsReplied, src => src.IsReplied)
                .Member(dest=>dest.BlogId, src=>src.BlogId)
                .Member(dest => dest.UserSenderId, src => src.UserSenderId)
                .Member(dest => dest.UserReceiverId, src => src.UserReceiverId);

            Mapper.Register<MessageEf, MessageEf>()
                .Member(dest => dest.MessageId, src => src.MessageId)
                .Member(dest => dest.Content, src => src.Content)
                .Member(dest => dest.Status, src => src.Status);
        }

        private static void RegisterBlogMappings()
        {
            Mapper.Register<BlogEf, BlogDto>()
                .Member(dest => dest.BlogId, src => src.BlogId)
                .Member(dest => dest.Title, src => src.Title)
                .Member(dest => dest.Image, src => src.Image)
                .Member(dest => dest.Content, src => src.Content)
                .Member(dest => dest.DateTimePublished, src => src.DateTimePublished)
                .Member(dest => dest.UserPublished, src => src.UserPublished)
                .Member(dest => dest.EntityStatus, src => src.EntityStatus)
                .Member(dest => dest.Messages, src => src.Comments);
            
            Mapper.Register<BlogEf, BlogEf>()
                .Member(dest => dest.BlogId, src => src.BlogId)
                .Member(dest => dest.Title, src => src.Title)
                .Member(dest => dest.Content, src => src.Content)
                .Member(dest => dest.EntityStatus, src => src.EntityStatus)
                .Member(dest => dest.Image, src => src.Image);
        }

        private static void RegisterContactUsMappings()
        {
            Mapper.Register<ContactUsEf,ContactUsEf>()
                .Member (dest => dest.Name, src => src.Name)
                .Member (dest => dest.Email, src => src.Email)
                .Member (dest => dest.PhoneNumber, src => src.PhoneNumber)
                .Member(dest => dest.Subject, src => src.Subject)
                .Member(dest => dest.Message, src => src.Message)
                .Member( dest => dest.DateTime, src => src.DateTime);
            
            Mapper.Register<ContactUsEf,ContactUsDto>()
                .Member(dest=> dest.Id, src=>src.Id)
                .Member (dest => dest.Name, src => src.Name)
                .Member (dest => dest.Email, src => src.Email)
                .Member (dest => dest.PhoneNumber, src => src.PhoneNumber)
                .Member(dest => dest.Subject, src => src.Subject)
                .Member(dest => dest.Message, src => src.Message)
                .Member( dest => dest.DateTime, src => src.DateTime);
            
            Mapper.Register<ContactUsDto,ContactUsEf>()
                .Member(dest=> dest.Id, src=>src.Id)
                .Member (dest => dest.Name, src => src.Name)
                .Member (dest => dest.Email, src => src.Email)
                .Member (dest => dest.PhoneNumber, src => src.PhoneNumber)
                .Member(dest => dest.Subject, src => src.Subject)
                .Member(dest => dest.Message, src => src.Message)
                .Member( dest => dest.DateTime, src => src.DateTime);
        }

        private static void RegisterProductMappings()
        {
            Mapper.Register<ProductDto, ProductEf>()
                .Member(x => x.ProductId, y => y.ProductId)
                .Member(x => x.ProductName, y => y.Name)
                .Member(x => x.ShortDescription, y => y.ShortDescription)
                .Member(x => x.FullDescription, y => y.FullDescription)
                .Member(x => x.StartAmount, y => y.StartAmount)
                .Member(x => x.CurrentAmount, y => y.CurrentAmount)
                .Member(x => x.StartPrice, y => y.Price)
                .Member(x => x.Discount, y => y.PercentageDiscount)
                .Member(x => x.Image, y => y.Image)
                .Member(x => x.EntityStatus, y => y.EntityStatus)
                .Member(x => x.CategoryId, y => y.CategoryId);

            Mapper.Register<ProductEf, ProductDto>()
                .Member(x => x.ProductId, y => y.ProductId)
                .Member(x => x.Name, y => y.ProductName)
                .Member(x => x.ShortDescription, y => y.ShortDescription)
                .Member(x => x.FullDescription, y => y.FullDescription)
                .Member(x => x.StartAmount, y => y.StartAmount)
                .Member(x => x.CurrentAmount, y => y.CurrentAmount)
                .Member(x => x.Price, y => y.StartPrice)
                .Member(x => x.PercentageDiscount, y => y.Discount)
                .Member(x => x.Image, y => y.Image)
                .Member(x => x.EntityStatus, y => y.EntityStatus)
                .Member(x => x.CategoryId, y => y.CategoryId)
                .Member(x => x.Views, y => y.Views);

            Mapper.Register<ProductEf, ProductEf>()
                .Member(x => x.ProductId, y => y.ProductId)
                .Member(x => x.ProductName, y => y.ProductName)
                .Member(x => x.ShortDescription, y => y.ShortDescription)
                .Member(x => x.FullDescription, y => y.FullDescription)
                .Member(x => x.StartAmount, y => y.StartAmount)
                .Member(x => x.CurrentAmount, y => y.CurrentAmount)
                .Member(x => x.StartPrice, y => y.StartPrice)
                .Member(x => x.Discount, y => y.Discount)
                .Member(x => x.Image, y => y.Image)
                .Member(x => x.EntityStatus, y => y.EntityStatus)
                .Member(x => x.CategoryId, y => y.CategoryId)
                .Ignore(x => x.DatePost);
        }
        
        private static void RegisterUserMappings()
        {
            Mapper.Register<UserDto, UserEf>()
                .Member(dest => dest.UserId, src => src.Id)
                .Member(dest => dest.FullName, src => src.FullName)
                .Member(dest => dest.Email, src => src.Email)
                .Member(dest => dest.UserType, src => src.UserType)
                .Member(dest => dest.UserStatus, src => src.UserStatus)
                .Member(dest => dest.IsVerified, src => src.IsVerified)
                .Member(dest => dest.IsSignUpForLetters, src => src.IsSignUpForLetters);
        
            Mapper.Register<UserEf,UserDto>()
                .Member(dest => dest.Id, src => src.UserId)
                .Member(dest => dest.FullName, src => src.FullName)
                .Member(dest => dest.Email, src => src.Email)
                .Member(dest=>dest.DateRegistered, src=>src.DateRegistered)
                .Member(dest => dest.UserType, src => src.UserType)
                .Member(dest=> dest.UserStatus, src => src.UserStatus)
                .Member(dest => dest.IsVerified, src => src.IsVerified)
                .Member(dest => dest.IsSignUpForLetters, src => src.IsSignUpForLetters);
        
            Mapper.Register<SignUpDto, UserEf>()
                .Member(dest => dest.FullName, src => src.FullName)
                .Member(dest => dest.Email, src => src.Email)
                .Member(dest => dest.PasswordHash, src => HashingUtility.HashPasswordSha256(src.Password))
                .Member(dest => dest.IsSignUpForLetters,
                    src => src.SignUpForNewsletter ? SignUpForLettersStatus.Yes : SignUpForLettersStatus.No);
        
            Mapper.Register<UserEf, UserEf>()
                .Member(dest => dest.UserId, src => src.UserId)
                .Member(dest => dest.FullName, src => src.FullName)
                .Member(dest => dest.Email, src => src.Email)
                .Member(dest => dest.UserType, src => src.UserType)
                .Member(dest => dest.UserStatus, src => src.UserStatus)
                .Member(dest => dest.IsVerified, src => src.IsVerified)
                .Member(dest => dest.IsSignUpForLetters, src => src.IsSignUpForLetters)
                .Ignore(dest => dest.DateRegistered);
        }
    }
}