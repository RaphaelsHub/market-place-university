using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProject.ModelAccessLayer.Model
{
    public class AllCategories
    {
        public List<Category> Categories { get; set; }

        public AllCategories()
        {
            Categories = new List<Category>();
        }
    }
}
