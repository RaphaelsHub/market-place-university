using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProject.ModelAccessLayer.Model
{
    public class AllProducts
    {
        public List<Product> Products { get; set; }

        public AllProducts()
        {
            Products = new List<Product>();
        }
    }
}
