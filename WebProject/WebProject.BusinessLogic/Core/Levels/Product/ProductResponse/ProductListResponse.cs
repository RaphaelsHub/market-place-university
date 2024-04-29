using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.ModelAccessLayer.Model;

namespace WebProject.BusinessLogic.Core.Levels.ProductResponse
{
    public class ProductListResponse
    {
        public List<Product> Data { get; set; }
        public bool IsExist { get; set; }
        public string ResponseMessage { get; set; }
    }
}
