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

        //static private ProductAPI _productAPI = new ProductAPI(); нет нужнды испольлзовать UserBase уже наследует этот класс, использую это на фронте.

        //НУЖНО РЕАЛИЗОВАТЬ ЭТО ПОЛУЧЕНИЯ СПИСКА ВСЕХ ЗАКАЗОВ ДЛЯ АДМИНА
        public AllDeliveries GetAllActiveOrder()
        {
            AllDeliveries a = new AllDeliveries();

            return a;
        }

        public new AllProducts GetAllProducts() => base.GetAllProducts();

        public bool AddProduct(Product product)
        {
            CreateBaseCategory();
            var productEF = ConvertProductDataEF(product);
            productEF.Owner = _userAPI.GetSuperAdmin();

            var baseCategoryResponse = GetBaseCategory();
            if (baseCategoryResponse.IsExist == false)
                return false;
            productEF.Category = baseCategoryResponse.Data;

            var response = AddProductDataToDB(productEF);
            return response.Status; // response.Status (true -> added to DB, false -> cant added to DB)
        }

        // response.Status (true -> deleted from DB, false -> cant deleted from DB)
        public bool DeleteOrderModel(int idOrder) => _userAPI.SuperAdminDeleteOrderModel(idOrder).Status;

        public bool DeleteProduct(int id) => DeleteProductDataByID(id).Status;

        public bool EditProduct(Product updatedProduct)
        {
            var productEF = ConvertProductDataEF(updatedProduct);
            var response = ModifyProductData(productEF);
            return response.Status;// response.Status (true -> prod is updated, false -> prod cant updated)
        }

        public bool AddToCart(CartItem cartItem) => this is IRegistered && _userBL.AddToCart(cartItem);

        public bool DeleteFromCart(CartItem cartItem) => this is IRegistered && _userBL.DeleteFromCart(cartItem);

        public bool ProcessOrder(OrderModel orderModel) => this is IRegistered && _userBL.ProcessOrder(orderModel);

        public CartData ViewCart(int indexUser) => this is IRegistered ? _userBL.ViewCart(indexUser) : null;

        public AllDeliveries ViewOrders(int indexUser) => this is IRegistered ? _userBL.ViewOrders(indexUser) : null;


        //Convert
        static private ProductDataEff ConvertProductDataEF(Product product)
        {
            var productEF = new ProductDataEff
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
        static private Product ConvertProduct(ProductDataEff data)
        {
            return new Product
            {
                Id = data.Id,
                Name = data.Name,
                Details = data.Details,
                ShortDescription = data.ShortDescription,
                FullDescription = data.FullDescription,
                PhotoUrl = data.GetPhotos(),
                Price = data.Price,
                Amount = data.Amount
            };
        }
        static private AllProducts ConvertAllProducts(List<ProductDataEff> listData)
        {
            var allProductList = new List<Product>();
            foreach (ProductDataEff productData in listData)
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
        static private Product GenerateProduct(ProductDataEff data)
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
            var cartData = GenerateCartData(data.CartItems);

            var StatusDelivery = GenerateStatusDelivery(data.StatusDelivery);

            return new OrderModel
            {
                Id = data.Order_Id,
                OrderInfo = orderInfo,
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