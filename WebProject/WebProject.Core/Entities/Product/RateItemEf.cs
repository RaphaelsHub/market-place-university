namespace WebProject.Core.Entities.Product
{
    public class RateItemEf
    {
        public uint RateItemId { get; set; }
        public float Rate { get; set; } = 0;
        public string FullName { get; set; }
        public string Comment { get; set; }
        public uint ProductId { get; set; }
        public ProductEf Product { get; set; }
    }
}