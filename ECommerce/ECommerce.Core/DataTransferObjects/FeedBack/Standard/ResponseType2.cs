namespace ECommerce.Core.DataTransferObjects.FeedBack.Standard
{
    public class ResponseType2 <T, T1>
    {
        public T Data { get; set; } = default;
        public T1 Data1 { get; set; } = default;
        public string Message { get; set; } = string.Empty;
    }
}