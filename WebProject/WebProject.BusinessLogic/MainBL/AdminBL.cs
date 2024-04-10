using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.BusinessLogic.Interfaces;
using WebProject.ModelAccessLayer.Model;

namespace WebProject.BusinessLogic.MainBL
{
    public class AdminBL : UserBL, IAdmin
    {
        public bool AddProduct(Product product)
        {
            return true;
        }

        public bool DeleteOrderModel(int IdOrder)
        {
            return true;
        }

        public bool DeleteProduct(int id)
        {
            return true;
        }

        public bool EditProduct(Product updatedProduct)
        {
            return true;
        }

        public AllDeliveries GetAllActiveOrder()
        {
            AllDeliveries a = new AllDeliveries();

            return a;
        }

        public AllProducts GetAllProducts()
        {
            AllProducts a  = new AllProducts();

            return a;
        }
    }
}
