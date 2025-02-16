namespace ECommerce.Core.Models.ViewModels
{
    public class ResponseViewModel <T>
    {
        public T Data { get;  set; }
        public string Message { get; set; }
        
        public ResponseViewModel(T data, string message)
        {
            Data = data;
            Message = message;
        }
    }
}