using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.ModelAccessLayer.Model;


namespace WebProject.BusinessLogic.Interfaces
{
    public interface IAdmin : IRegistered
    {
        bool AddProduct(Product product);
        bool EditProduct(Product updatedProduct);
        List<Product> GetAllProducts();
        List<OrderModel> GetAllActiveOrder();
        bool DeleteProduct(int idProduct);
        bool DeleteOrderModel(int idOrder);
    }
}
