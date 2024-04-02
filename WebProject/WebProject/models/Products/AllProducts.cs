using System.Collections.Generic;

namespace WebProject.Models.Products
{
    public class AllProducts
    {
        public List<Product> products { get; set; }

        public AllProducts() 
        {
            products = new List<Product>();
        }
    }
}