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
            var blogEf = await _blogsRepository.CreateAsync(new BlogEf(blog));
            return new BaseResponse<BlogDto>(Mapper.Map<BlogEf,BlogDto>(blogEf));
        }
        
        public async Task<BaseResponse<BlogDto>> UpdateBlogAsync(BlogDto blog)
        {
            var blogEf = await _blogsRepository.UpdateAsync(new BlogEf(blog));
            return new BaseResponse<BlogDto>(Mapper.Map<BlogEf,BlogDto>(blogEf));
        }
        
        public async Task<BaseResponse<bool>> DeleteBlogByIdAsync(int idBlog)
        {
            await _blogsRepository.DeleteByIdAsync(idBlog);
            return new BaseResponse<bool>( await _blogsRepository.GetByIdAsync(idBlog) == null);
        }
        
        public async Task<BaseResponse<BlogDto>> GetBlogByIdAsync(int idBlog)
        {
            var blogEf =await _blogsRepository.GetByIdAsync(idBlog); 
            
            if (blogEf == null) return new BaseResponse<BlogDto>(null,OperationStatus.Error, "Blog not found!");
            
            blogEf.SetComments(await _messagesRepository.GetMessagesByIdAsync(idBlog));
            
            var blogDto = Mapper.Map<BlogEf,BlogDto>(blogEf);
            
            blogDto.Messages  = Mapper.Map<IEnumerable<MessageEf>,IEnumerable<MessageDto>>(blogEf.GetComments()).OrderBy(x=>x.DateSent).ToList(); 
            
            return new BaseResponse<BlogDto>(blogDto);
        }
        
        public async Task<BaseResponse<List<BlogDto>>> GetBlogsByTitleAsync(string searchByName, int currentPage, int amountOfItems)
        {
            var blogsEf =await _blogsRepository.GetPaginatedBlogsByNameAsync(searchByName, currentPage, amountOfItems);
            
            if (blogsEf == null) return new BaseResponse<List<BlogDto>>(null,OperationStatus.Error, "No blogs found!");
            
            return new BaseResponse<List<BlogDto>>(Mapper.Map<List<BlogEf>,List<BlogDto>>(blogsEf.ToList()));
        }
        
        public async Task<BaseResponse<List<BlogDto>>> GetLatestBlogsAsync(int amountOfItems)
        {
            var blogsEf =await _blogsRepository.GetLatestBlogsAsync(amountOfItems);
            
            if (blogsEf == null) return new BaseResponse<List<BlogDto>>(null,OperationStatus.Error, "No blogs found!");
            
            return new BaseResponse<List<BlogDto>>(Mapper.Map<List<BlogEf>,List<BlogDto>>(blogsEf.ToList()));
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