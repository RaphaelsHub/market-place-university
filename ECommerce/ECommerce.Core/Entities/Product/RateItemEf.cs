namespace ECommerce.Core.Entities.Product
{
    public class RateItemEf
    {
        public int RateItemId { get; set; }
        public float Rate { get; set; } = 0;
        public string FullName { get; set; }
        public string Comment { get; set; }
        public int ProductId { get; set; }
        public ProductEf Product { get; set; }
    }
}