using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.BusinessLogic.Core;
using WebProject.BusinessLogic.Core.Levels;
using WebProject.BusinessLogic.Interfaces;
using WebProject.ModelAccessLayer.Model;

using WebProject.Domain.Entities.DBModels;
using WebProject.Domain.Entities.User;
using WebProject.Domain.Enum;

namespace WebProject.BusinessLogic.MainBL
{
    public class AdminBL : UserBL, IAdmin, IUserBase
    {
        static private UserAPI _userAPI = new UserAPI();
        static private ProductAPI _productAPI = new ProductAPI();
        public bool AddProduct(Product product)
        {
            var productEF = ConvertProductDataEF(product);
            productEF.Owner = _userAPI.GetSuperAdmin();
            var response = _productAPI.AddProductDataToDB(productEF);
            return response.Status; // response.Status (true -> added to DB, false -> cant added to DB)
        }

        public bool DeleteOrderModel(int idOrder) 
        {
            return true;
        }

        public bool DeleteProduct(int id)
        {
            var response = _productAPI.DeleteProductDataByID(id);
            return response.Status; // response.Status (true -> deleted from DB, false -> cant deleted from DB)
        }

        public bool EditProduct(Product updatedProduct)
        {
            var productEF = ConvertProductDataEF(updatedProduct);
            productEF.Id = updatedProduct.Id;
            var response = _productAPI.ModifyProductData(productEF);
            return response.Status;// response.Status (true -> prod is updated, false -> prod cant updated)
        }

        public AllDeliveries GetAllActiveOrder() 
        {
            AllDeliveries a = new AllDeliveries();

            return a;
        }

        public AllProducts GetAllProducts()
        {
            AllProducts a = new AllProducts();

            return a;
        }

        // Metods from UserBL? unessesary to change

        /*public bool AddToCart(CartItem cartItem)
        {
            return false;
        }

        public bool DeleteFromCart(CartItem cartItem)
        {
            return true;
        }

        public bool ProcessOrder(OrderModel orderModel)
        {
            return true;
        }


        public CartData ViewCart(int indexUser)
        {
            return null;
        }

        public AllDeliveries ViewOrders(int indexUser)
        {
            return null;
        } */
    
        //Convert
        static private ProductDataEF ConvertProductDataEF(Product product)
        {
            var productEF = new ProductDataEF
            {
                Name = product.Name,
                Details = product.Details,
                ShortDescription = product.ShortDescription,
                FullDescription = product.FullDescription,
                Price = product.Price,
                Amount = product.Amount,
            };
            productEF.SetPhotos(product.PhotoUrl);
            return productEF;
        }

        static private Product ConvertProduct(ProductDataEF data)
        {
            return new Product
            {
                Id = data.Id,
                Name = data.Name,
                Details = data.Details,
                filter = null, // По вопросам к Саше или Ивану
                ShortDescription = data.ShortDescription,
                FullDescription = data.FullDescription,
                PhotoUrl = data.GetPhotos(),
                Price = data.Price,
                Amount = data.Amount
            };
        }

        static private AllProducts ConvertAllProducts(List<ProductDataEF> listData)
        {
            var allProductList = new List<Product>();
            foreach (ProductDataEF productData in listData)
            {
                allProductList.Add(ConvertProduct(productData));
            }

            return new AllProducts { Products = allProductList };
        }


        //Chirill metods
        static private Dictionary<string, StatusDelivery> StatusDeliveryDictionary = new Dictionary<string, StatusDelivery>
        {
            {"Pending", StatusDelivery.Pending},                // Ожидание
            {"Processing" , StatusDelivery.Processing},         // Обработка
            {"Shipped" , StatusDelivery.Shipped},               // Отправлено
            {"OutForDelivery" , StatusDelivery.OutForDelivery },// В пути
            {"Delivered" , StatusDelivery.Delivered },          // Доставлено
            {"Returned" , StatusDelivery.Returned },            // Возвращено
            {"Canceled" , StatusDelivery.Canceled }             // Отменено
        };
        static private Product GenerateProduct(ProductDataEF data)
        {
            return new Product
            {
                Id = data.Id,
                Name = data.Name,
                Details = data.Details,
                FullDescription = data.FullDescription,
                ShortDescription = data.ShortDescription,
                Amount = data.Amount,
                Price = data.Price,
                filter = null,
                PhotoUrl = null // написать ване
            };
        }
        static private CartData GenerateCartData(ICollection<CartItemEF> userCart)
        {
            List<Tuple<Product, int>> productList = new List<Tuple<Product, int>>();
            decimal sumPrice = 0;
            decimal deliveryPrice = 0;
            decimal finalPrice = 0;

            foreach (CartItemEF cartItem in userCart)
            {
                var par = new Tuple<Product, int>(
                    GenerateProduct(cartItem.Product),
                    cartItem.Quantity);
                sumPrice += cartItem.Product.Price * cartItem.Quantity;
                productList.Add(par);
            }
            finalPrice = sumPrice + deliveryPrice;
            return new CartData
            {
                SumPrice = sumPrice,
                DeliveryPrice = deliveryPrice,
                FinalPrice = finalPrice,
                productList = productList
            };
        }
        static private StatusDelivery GenerateStatusDelivery(string RawOrderStatusEF)
        {
            if (AdminBL.StatusDeliveryDictionary.TryGetValue(RawOrderStatusEF, out StatusDelivery result))
            {
                return result;
            }
            else
            {
                return 0; //нужно придумать возврат некоректных данных
            }
        }
        static private OrderModel GenerateOrderModel(OrderEF data)
        {
            var orderInfo = new OrderInfo
            {
                UserId = data.UserId,

                Name = data.Name,
                Email = data.Email,
                Phone = data.Phone,
                Country = data.Country,
                City = data.City,
                Address = data.Address,
                Comment = data.Comment,
            };
            var cardCred = new CardCreditionals();
            var cartData = GenerateCartData(data.CartItems);

            var StatusDelivery = GenerateStatusDelivery(data.StatusDelivery);

            return new OrderModel
            {
                Id = data.Order_Id,
                OrderInfo = orderInfo,
                CardCreditinals = cardCred,
                CartData = cartData,
                StatusDelivery = StatusDelivery
            };

        }
        static private AllDeliveries GenerateDeliveries(ICollection<OrderEF> orders)
        {
            var deliverisList = new List<OrderModel>();

            foreach (var order in orders)
            {
                deliverisList.Add(GenerateOrderModel(order));
            }
            return new AllDeliveries
            {
                AllOrders = deliverisList
            };
        }
    }
}