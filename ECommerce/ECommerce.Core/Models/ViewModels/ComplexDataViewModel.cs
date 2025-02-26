namespace ECommerce.Core.Models.ViewModels
{
    public class ComplexDataViewModel<T,T1,T2>
    {
        public T Data { get; set; }
        public T1 Data1 { get; set; }
        public T2 Data2 { get; set; }

        public ComplexDataViewModel(T data, T1 data1, T2 data2)
        {
            Data = data;
            Data1 = data1;
            Data2 = data2;
        }
    }
}