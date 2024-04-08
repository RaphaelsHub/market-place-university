using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.ModelAccessLayer.Model;
using WebProject.Domain.Enum;

namespace WebProject.ModelAccessLayer.Model
{
    public class Category
    {
        public int IdCategory {  get; set; }
        public string Name { get; set; }
        public List<Category> Subcategories { get; set; }

        public List<Product> Products { get; set; }
        public List<Feature> Filters { get; set; }

        public SortBy SortBy { get; set; } = SortBy.None;

        public Category()
        {
            Products = new List<Product>();
            Subcategories = new List<Category>();
            Filters = new List<Feature>();
        }
    }
}
