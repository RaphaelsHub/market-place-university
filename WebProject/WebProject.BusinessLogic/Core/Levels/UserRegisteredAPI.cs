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
                // Проверяем есть ли уже такой элемент в корзине
                var existingCartItem = db.CartItems
                    .FirstOrDefault(c => c.UserDataId == cartItem.UserDataId && c.ProductId == cartItem.ProductId);

                if (existingCartItem != null)
                    existingCartItem.Quantity += cartItem.Quantity;
                else
                    db.CartItems.Add(cartItem);

                db.SaveChanges();

                return existingCartItem ?? cartItem;
            }
        }
        internal StandartResponse AddToUserCart(CartItemDataEF cartItem)
        {
            if (cartItem == null)
                return new StandartResponse { Status = false, ResponseMessage = "cartItem is null" };

            var userResponse = FindUserEF(cartItem.UserDataId);

            if (userResponse.IsExist == false)
                return new StandartResponse { Status = false, ResponseMessage = "User not found in database." };

            return CreateOrUpdateCartItemEF(cartItem) == cartItem ? new StandartResponse { Status = true, ResponseMessage = "Was Added" }
            : new StandartResponse { Status = false, ResponseMessage = "Some errors" };
        }
        internal StandartResponse DeleteFromUserCart(CartItem cartItem)
        {
            using (var db = new Context())
            {
                var cartItemEF = db.CartItems.FirstOrDefault(u => u.CartItemId == cartItem.Id && u.UserDataId == cartItem.Id);

                if (cartItemEF != null)
                {
                    db.CartItems.Remove(cartItemEF);
                    db.SaveChanges();
                    return new StandartResponse { Status = true };
                }
                else
                {
                    return new StandartResponse { Status = false, ResponseMessage = "User not found in database or product" };
                }
            }
        }
        internal DataResponse<OrderDataEF> ProcessUserOrder(OrderModel orderModel)
        {
            using (var db = new Context())
            {
                var user = db.Users.FirstOrDefault(u => u.UserDataId == orderModel.OrderInfo.UserId);
                
                if (user != null)
                {
                    if (user.CartItems.Count() <= 0)
                        return new DataResponse<OrderDataEF> { Data = null, IsExist = false, ResponseMessage = "User dont have any item in cart" };
                    
                    OrderDataEF orderDataEF = ModelGeneratingClass.GenerateInfoDataEF(orderModel.OrderInfo);
                    orderDataEF.User = user;
                    orderDataEF.UserDataId = orderModel.OrderInfo.UserId;
                    orderDataEF.StatusDelivery = orderModel.StatusDelivery;
                    
                    orderDataEF.CartItems = user.CartItems;
                    user.CartItems.Clear();
                    user.Orders.Add(orderDataEF);
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
                var userFromDb = db.Users.FirstOrDefault(u => u.UserDataId == indexUser);
                if (userFromDb != null)
                {
                    if (userFromDb.CartItems.Count() <= 0)
                        return new DataResponse<List<CartItemDataEF>> { Data = null, IsExist = false, ResponseMessage = "User dont have any item in cart" };
                    
                    var userCartItems = new List<CartItemDataEF>(userFromDb.CartItems);
                    
                    return new DataResponse<List<CartItemDataEF>> { Data = userCartItems, IsExist = true };
                }
                return new DataResponse<List<CartItemDataEF>> { Data = null, IsExist = false, ResponseMessage = "User not found in database." };
            }
        }
        internal DataResponse<List<OrderDataEF>> ViewUserOrders(int indexUser)
        {
            using (var db = new Context())
            {
                var userFromDb = db.Users.FirstOrDefault(u => u.UserDataId == indexUser);

                if (userFromDb != null)
                {
                    if (userFromDb.Orders.Count() <= 0)
                        return new DataResponse<List<OrderDataEF>> { Data = null, IsExist = false, ResponseMessage = "User dont have any orders" };
                    
                    var userCartItems = new List<OrderDataEF>(userFromDb.Orders);

                    return new DataResponse<List<OrderDataEF>> { Data = userCartItems, IsExist = true };
                }
                return new DataResponse<List<OrderDataEF>> { Data = null, IsExist = false, ResponseMessage = "User not found in database." };
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
        internal DataResponse<UserDataEF> FindUserEF(int indexUser)
        {
            using (var db = new Context())
            {
                var userDB = db.Users.FirstOrDefault(u => u.UserDataId == indexUser);

                return userDB != null && userDB.CartItems!=null ? new DataResponse<UserDataEF> { Data = userDB, IsExist = true, ResponseMessage = "Succesfully entered!" }
                : new DataResponse<UserDataEF> { Data = null, IsExist = false, ResponseMessage = "This User with userId dont exist" };
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