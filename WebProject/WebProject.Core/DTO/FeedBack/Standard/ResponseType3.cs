namespace WebProject.Core.DTO.FeedBack.Standard
{
    public class ResponseType3<T,T1,T2>
    {
        // Response model
        public T Data { get; set; } = default;
        
        // Additional data
        public T1 Data1 { get; set; } = default;
        
        // Additional data
        public T2 Data2 { get; set; } = default;
        
        public string Message { get; set; } = string.Empty;
    }
}