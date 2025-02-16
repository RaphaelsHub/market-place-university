namespace ECommerce.Core.Models.ViewModels
{
    public class ResponseViewModel3<T,T1,T2>
    {
        public T Data { get; set; } = default;
        public T1 Data1 { get; set; } = default;
        public T2 Data2 { get; set; } = default;
        public string Message { get; set; } = string.Empty;
        
        public ResponseViewModel3() { }
    }
}