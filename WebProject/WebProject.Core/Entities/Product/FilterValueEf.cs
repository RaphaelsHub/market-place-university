namespace WebProject.Core.Entities.Product
{
    public class FilterValueEf
    {
        public uint FilterValueId { get; set; }
        public string FilterValueName { get; set; }
        public bool IsAvailable { get; set; } = false;

        public uint FilterId { get; set; }
        public FilterEf Filter { get; set; }
    }
}