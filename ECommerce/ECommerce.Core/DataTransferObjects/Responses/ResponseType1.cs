namespace ECommerce.Core.DataTransferObjects.Responses
{
    public class ResponseType1 <T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        
        public ResponseType1(T data = default, string message = "")
        {
            Data = data;
            Message = message;
        }
    }
}