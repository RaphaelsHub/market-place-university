namespace ECommerce.Core.Entities.Product
{
    public class FilterValueEf
    {
        public int FilterValueId { get; set; }
        public string FilterValueName { get; set; }

        public int FilterId { get; set; }
        public FilterEf Filter { get; set; }
    }
}