namespace ECommerce.Core.Models.ViewModels
{
    public class ResponseViewModel2 <T, T1>
    {
        public T Data { get; set; } = default;
        public T1 Data1 { get; set; } = default;
        public string Message { get; set; } = string.Empty;
        public ResponseViewModel2() { }
    }
}