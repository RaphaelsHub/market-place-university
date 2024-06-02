using System;
using System.Collections.Generic;
using System.Linq;
using WebProject.BusinessLogic.Core.Levels.GeneralResponse;
using WebProject.BusinessLogic.MainBL;
using WebProject.Domain;
using WebProject.Domain.DB;
using WebProject.ModelAccessLayer.Model;

namespace WebProject.BusinessLogic.Core
{
    public class UserRegisteredAPI
    {
        internal CartItemDataEF CreateOrUpdateCartItemEF(CartItemDataEF cartItem)
        {
            using (var db = new Context())
            {
                var existingCartItem = db.CartItems
                    .FirstOrDefault(c => c.UserDataId == cartItem.UserDataId && c.ProductId == cartItem.ProductId);
                 
                if (existingCartItem != null)
                {
                    existingCartItem.Quantity += cartItem.Quantity;
                }
                else
                {
                    var user = db.Users.FirstOrDefault(u => u.UserDataId == cartItem.UserDataId);
                    if (user != null)
                    {
                        // Обновляем навигационное свойство у cartItem
                        cartItem.User = user;
                        // Добавляем элемент корзины в базу данных
                        db.CartItems.Add(cartItem);
                        // Обновляем навигационное свойство у пользователя
                    }
                }

                db.SaveChanges();

                var a = db.CartItems
                    .FirstOrDefault(c => c.UserDataId == cartItem.UserDataId && c.ProductId == cartItem.ProductId);
                return a;
            }
        }

        internal StandartResponse AddToUserCart(CartItemDataEF cartItem)
        {
            if (cartItem == null)
                return new StandartResponse { Status = false, ResponseMessage = "cartItem is null" };

            var userResponse = FindUserEF(cartItem.UserDataId);

            if (userResponse.Status == false)
                return new StandartResponse { Status = false, ResponseMessage = "User not found in database." };


            return CreateOrUpdateCartItemEF(cartItem) != null ?
                new StandartResponse { Status = true, ResponseMessage = "Was Added" }
            : new StandartResponse { Status = false, ResponseMessage = "Some errors" };
        }
        internal StandartResponse DeleteFromUserCart(CartItem cartItem)
        {
            using (var db = new Context())
            {
                var existingCartItem = db.CartItems
                    .FirstOrDefault(c => c.UserDataId == cartItem.Id_User && c.ProductId == cartItem.Id);

                if (existingCartItem != null)
                {
                    existingCartItem.Quantity -= cartItem.Quantity;
                    if (existingCartItem.Quantity <= 0)
                    {
                        db.CartItems.Remove(existingCartItem);
                    }

                    db.SaveChanges();
                    return new StandartResponse { Status = true };
                }
                return new StandartResponse { Status = false, ResponseMessage = "User not found in database or product" };
            }
        }
        internal DataResponse<OrderDataEF> ProcessUserOrder(OrderModel orderModel)
        {
            if (orderModel?.OrderInfo?.UserId == null)
                return new DataResponse<OrderDataEF> { Data = null, IsExist = false, ResponseMessage = "User doesn't have any item in cart" };

            using (var db = new Context())
            {
                var user = db.Users.FirstOrDefault(u => u.UserDataId == orderModel.OrderInfo.UserId);

                if (user != null)
                {
                    var cartItems = db.CartItems.Where(c => c.UserDataId == orderModel.OrderInfo.UserId).ToList();

                    if (!cartItems.Any())
                        return new DataResponse<OrderDataEF> { Data = null, IsExist = false, ResponseMessage = "User doesn't have any items in cart" };

                    OrderDataEF orderDataEF = ModelGeneratingClass.GenerateInfoDataEF(orderModel.OrderInfo);
                    orderDataEF.User = user;
                    orderDataEF.UserDataId = orderModel.OrderInfo.UserId;
                    orderDataEF.StatusDelivery = orderModel.StatusDelivery;
                    orderDataEF.CartItems = cartItems;

                    user.Orders.Add(orderDataEF);

                    db.Orders.Add(orderDataEF);

                    // Remove items from the cart
                    db.CartItems.RemoveRange(cartItems);

                    db.SaveChanges();

                    return new DataResponse<OrderDataEF> { Data = orderDataEF, IsExist = true };
                }

                return new DataResponse<OrderDataEF> { Data = null, IsExist = false, ResponseMessage = "User not found in database." };
            }
        }

        internal DataResponse<List<CartItemDataEF>> ViewUserCart(int indexUser)
        {
            using (var db = new Context())
            {
                var userCartItems = db.CartItems.Where(c => c.UserDataId == indexUser).ToList();

                if (userCartItems != null && userCartItems.Any())
                {
                    return new DataResponse<List<CartItemDataEF>> { Data = userCartItems, IsExist = true };
                }
                else
                {
                    return new DataResponse<List<CartItemDataEF>> { Data = null, IsExist = false, ResponseMessage = "User doesn't have any items in the cart." };
                }
            }
        }



        internal DataResponse<List<OrderDataEF>> ViewUserOrders(int indexUser)
        {
            using (var db = new Context())
            {
                var orders = db.Orders.Where(o => o.UserDataId == indexUser).ToList();

                if (orders != null && orders.Count > 0)
                {
                    return new DataResponse<List<OrderDataEF>>
                    {
                        Data = orders,
                        IsExist = true
                    };
                }

                return new DataResponse<List<OrderDataEF>>
                {
                    Data = null,
                    IsExist = false,
                    ResponseMessage = orders == null ? "User not found in database." : "User doesn't have any orders."
                };
            }
        }

        internal StandartResponse SuperAdminDeleteOrderModel(int idOrder)
        {
            using (var db = new Context())
            {
                var deletedOrder = db.Orders.FirstOrDefault(or => or.OrderDataId == idOrder);
                if (deletedOrder != null)
                {
                    db.Orders.Remove(deletedOrder);
                    db.SaveChanges();
                    return new StandartResponse { Status = true };
                }
                return new StandartResponse { Status = false, ResponseMessage = "Order not found in database." };
            }
        }
        internal StandartResponse FindUserEF(int indexUser)
        {
            using (var db = new Context())
            {
                var userDB = db.Users.FirstOrDefault(u => u.UserDataId == indexUser);

                return userDB != null ? new StandartResponse { Status = true, ResponseMessage = "There is such user!" }
                : new StandartResponse { Status = false, ResponseMessage = "There is no such user!" };
            }
        }
        internal DataResponse<List<OrderDataEF>> GetAllOrders()
        {
            using (var db = new Context()) 
            {
                var orders = new List<OrderDataEF>(db.Orders);
                return new DataResponse<List<OrderDataEF>>{ Data = orders };
            }
        }
        /*
        internal StandartResponse UpdateOrderInfo(OrderInfoReqest updated)
        {
            using (var db = new Context())
            {
                OrderEF findOrder = db.Orders.FirstOrDefault(or => or.Order_Id == updated.OrderId);
                if (findOrder != null)
                {
                    findOrder.Name = updated.Name;
                    findOrder.Email = updated.Email;
                    findOrder.Phone = updated.Phone;
                    findOrder.Country = updated.Country;
                    findOrder.City = updated.City;
                    findOrder.Address = updated.Address;
                    findOrder.Comment = updated.Comment;
                    findOrder.StatusDelivery = updated.StatusDelivery;
                    db.SaveChanges();
                    return new StandartResponse { Status = true };
                }
                else
                {
                    return new StandartResponse { Status = false, ResponseMessage = "Cant find order with id = updated.OrderId" };
                }
            }
        }


        internal StandartResponse SuperAdminEditProductData(ProductDataEff updatedProductData)
        {
            using (var db = new Context())
            {
                var existingProductData = db.Products.FirstOrDefault(p => p.Id == updatedProductData.Id);
                if (existingProductData != null)
                {
                    db.Entry(existingProductData).CurrentValues.SetValues(updatedProductData);
                    db.SaveChanges();
                    return new StandartResponse { Status = true };
                }
                else
                {
                    return new StandartResponse { Status = false, ResponseMessage = "ProductData not found in database." };
                }
            }
        }
        internal DataResponse<List<ProductDataEff>> SuperAdminGetAllProducts()
        {
            using (var db = new Context())
            {
                if (db.Products.Any())
                    return new DataResponse<List<ProductDataEff>> { Data = db.Products.ToList(), IsExist = true };
                else
                    return new DataResponse<List<ProductDataEff>> { Data = new List<ProductDataEff>(), IsExist = false, ResponseMessage = "There are no Products in the database" };
            }
        }

        public DataResponse<ProductDataEff> SuperAdminDeleteProductData(int idProductData)
        {
            using (var db = new Context())
            {
                //не проверяю принадлежность к админу потому что SuperAdmin
                var deletedProductData = db.Products.FirstOrDefault(p => p.Id == idProductData);
                if (deletedProductData != null)
                {
                    DeleteAllProductDataReferenseInCart(idProductData, db);
                    if (!FindAnyProductDataReferenseInOrders(idProductData, db))
                    {
                        db.Products.Remove(deletedProductData);
                        db.SaveChanges();
                        return new DataResponse<ProductDataEff>
                        {
                            Data = null,
                            IsExist = false,
                            ResponseMessage =
                            "This ProductData still full deleted, it dont exist any more in dataBase"
                        };
                    }
                    else
                    {
                        deletedProductData.Amount = 0;
                        return new DataResponse<ProductDataEff>
                        {
                            Data = deletedProductData,
                            IsExist = true,
                            ResponseMessage =
                            "This ProductData stil exist and have referense in Orders, but all UserCart referense was removed"
                        };
                    }
                }
                else
                {
                    return new DataResponse<ProductDataEff> { Data = null, IsExist = false, ResponseMessage = "This ProductData dont exist" };
                }
            }
        }
        private bool FindAnyProductDataReferenseInOrders(int idProductData, Context db)
        {
            return db.Orders.Any(u => u.CartItems.Any
            (ci => ci.ProductId == idProductData));
        }
        private void DeleteAllProductDataReferenseInCart(int idProductData, Context db)
        {
            var userIdsWithProductData = db.Users
                .Where(u => u.CartItems.Any(ci => ci.ProductId == idProductData))
                .Select(u => u.Id)
                .ToList(); //находит всех пользователй у которых есть искомый продукт именно в корзине
            foreach (var userId in userIdsWithProductData)
            {
                var cartItemsWithProductData = db.CartItems
                    .Where(ci => ci.UserId == userId && ci.ProductId == idProductData)
                    .ToList();
                db.CartItems.RemoveRange(cartItemsWithProductData);
                //удаляет искомый продукт у именно из корзин пользователей
            }
            db.SaveChanges();
        }
        */
    }
}