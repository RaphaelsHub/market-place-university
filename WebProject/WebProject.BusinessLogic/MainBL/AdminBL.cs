using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.BusinessLogic.Core;
using WebProject.BusinessLogic.Core.Levels;
using WebProject.BusinessLogic.Interfaces;
using WebProject.ModelAccessLayer.Model;
using WebProject.Domain.Enum;

namespace WebProject.BusinessLogic.MainBL
{
    public class AdminBL : UserBaseBL, IAdmin
    {
        private readonly UserRegisteredAPI _userAPI = new UserRegisteredAPI();

        private readonly UserBL _userBL = new UserBL();
        public new AllProducts GetAllProducts() => base.GetAllProducts();
        public bool AddToCart(CartItem cartItem) => this is IRegistered && _userBL.AddToCart(cartItem);

        public bool DeleteFromCart(CartItem cartItem) => this is IRegistered && _userBL.DeleteFromCart(cartItem);

        public bool ProcessOrder(OrderModel orderModel) => this is IRegistered && _userBL.ProcessOrder(orderModel);

        public CartData ViewCart(int indexUser) => this is IRegistered ? _userBL.ViewCart(indexUser) : null;

        public AllDeliveries ViewOrders(int indexUser) => this is IRegistered ? _userBL.ViewOrders(indexUser) : null;

        public bool DeleteProduct(int id) => DeleteProductDataByID(id).Status;

        public bool DeleteOrderModel(int idOrder) => _userAPI.SuperAdminDeleteOrderModel(idOrder).Status;

        public AllDeliveries GetAllActiveOrder() => new AllDeliveries 
        { 
            AllOrders = ModelGeneratingClass.GenerateDeliveries(_userAPI.GetAllOrders().Data, GetProductById) 
        };

        public bool AddProduct(Product product)
        {
            var response = AddProductDataToDB(ModelGeneratingClass.GenerateEfProduct(product));
            return response.Status; 
        }

        public bool EditProduct(Product updatedProduct)
        {
            var response = ModifyProductData(ModelGeneratingClass.GenerateEfProduct(updatedProduct));
            return response.Status;
        }


    }
}