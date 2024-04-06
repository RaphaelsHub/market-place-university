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

        public void DeleteOrderModel(OrderModel orderModel)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void EditProduct(Product updatedProduct)
        {
            throw new NotImplementedException();
        }

        public AllDeliveries GetAllActiveOrder()
        {
            AllDeliveries a = null;

            a = new AllDeliveries();

            return a;
        }

        public AllProducts GetAllProducts()
        {
            AllProducts a = null;

            a= new AllProducts();

            return a;
        }
    }
}
