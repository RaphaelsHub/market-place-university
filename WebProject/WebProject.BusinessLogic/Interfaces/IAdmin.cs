using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.ModelAccessLayer.Model;


namespace WebProject.BusinessLogic.Interfaces
{
    public interface IAdmin
    {
        bool AddProduct(Product product);
        void DeleteProduct(Product product);
        void EditProduct(Product updatedProduct);
        AllProducts GetAllProducts();
        AllDeliveries GetAllActiveOrder();
        void DeleteOrderModel(OrderModel orderModel);
    }
}
