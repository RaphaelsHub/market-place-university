using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.App.Interfaces.Blog;
using ECommerce.Core.Entities.Blog;
using ECommerce.Core.Enums.Request;
using ECommerce.Core.Interfaces.Blog;
using ECommerce.Core.Models.DTOs.Blog;
using ECommerce.Core.Models.DTOs.GenericResponses;
using ExpressMapper;

namespace ECommerce.App.Services.Blog
{
    public class BlogService : IBlogService
    {
        private readonly IBlogsRepository _blogsRepository;
        private readonly IMessagesRepository _messagesRepository;
        
        public BlogService(IBlogsRepository blogsRepository, IMessagesRepository messagesRepository)
        {
            _blogsRepository = blogsRepository;
            _messagesRepository = messagesRepository;
        }

        public async Task<BaseResponse<BlogDto>> CreateBlogAsync(BlogDto blog)
        {
            var blogEf = Mapper.Map<BlogDto,BlogEf>(blog);
            
            var createdBlog = await _blogsRepository.CreateAsync(blogEf);
            
            var createdBlogDto = Mapper.Map<BlogEf,BlogDto>(createdBlog);
            
            return new BaseResponse<BlogDto>(createdBlogDto);
        }

        public async Task<BaseResponse<BlogDto>> GetBlogByIdAsync(int idBlog)
        {
            var blogEf =await _blogsRepository.GetByIdAsync(idBlog);
            var messagesEf = await _messagesRepository.GetMessagesByIdAsync(idBlog);
            var messagesDto = Mapper.Map<IEnumerable<MessageEf>,IEnumerable<MessageDto>>(messagesEf).OrderBy(x=>x.DateSent).ToList(); 
            var blogDto = Mapper.Map<BlogEf,BlogDto>(blogEf);
            blogDto.Messages = messagesDto;
            return  new BaseResponse<BlogDto>(blogDto,OperationStatus.Success, "Blog found!");
        }

        public async Task<BaseResponse<IEnumerable<BlogDto>>> GetBlogsByTitleAsync(string searchByName, int currentPage, int amountOfItems)
        {
            var blogsEf =await _blogsRepository.GetPaginatedBlogsByNameAsync(searchByName, currentPage, amountOfItems);
            return new BaseResponse<IEnumerable<BlogDto>>(Mapper.Map<IEnumerable<BlogEf>,IEnumerable<BlogDto>>(blogsEf),OperationStatus.Success, "Blogs found!");
        }

        public async Task<BaseResponse<IEnumerable<BlogDto>>> GetLatestBlogsAsync(int amountOfItems)
        {
            var blogsEf =await _blogsRepository.GetLatestBlogsAsync(amountOfItems);
            return new BaseResponse<IEnumerable<BlogDto>>(Mapper.Map<IEnumerable<BlogEf>,IEnumerable<BlogDto>>(blogsEf),OperationStatus.Success, "Blogs found!");
        }

        public async Task<BaseResponse<BlogDto>> UpdateBlogAsync(BlogDto blog)
        {
            var blogEf = Mapper.Map<BlogDto,BlogEf>(blog);
            var blogEfUpdated = await _blogsRepository.UpdateAsync(blogEf);
            return new BaseResponse<BlogDto>(Mapper.Map<BlogEf,BlogDto>(blogEfUpdated),OperationStatus.Success, "Blog has been successfully updated!");
        }

        public async Task<BaseResponse<bool>> DeleteBlogByIdAsync(int idBlog)
        {
            await _blogsRepository.DeleteByIdAsync(idBlog);
            return new BaseResponse<bool>(true,OperationStatus.Success, "Blog has been successfully deleted!");
        }

        public async Task<BaseResponse<bool>> AddMessageToBlogAsync(int idBlog, MessageDto message)
        {
           var result=  await _messagesRepository.AddMessageAsync(idBlog, Mapper.Map<MessageDto,MessageEf>(message));
           bool messageAdded = result != null;
           return new BaseResponse<bool>(messageAdded,OperationStatus.Success, "Message has been successfully added!");
        }
        
        public async Task<BaseResponse<bool>> DeleteMessageFromBlogAsync(int idBlog, int idMessage)
        {
            await _messagesRepository.DeleteMessageByIdAsync(idBlog, idMessage);
            return new BaseResponse<bool>(true,OperationStatus.Success, "Message has been successfully deleted!");
        }
    }
}