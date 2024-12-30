namespace WebProject.Core.DTO.ResponcesDto
{
    public class TResponce<T> where T : class
    {
        public T Data { get; set; }
        public string Message { get; set; }
    }
}