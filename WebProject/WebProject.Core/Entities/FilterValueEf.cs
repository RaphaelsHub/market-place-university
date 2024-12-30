namespace WebProject.Core.Entities
{
    public class FilterValueEf
    {
        public uint FilterValueId { get; set; }
        public uint FilterId { get; set; }
        public string Value { get; set; }
        public bool IsAvailable { get; set; }
    }
}