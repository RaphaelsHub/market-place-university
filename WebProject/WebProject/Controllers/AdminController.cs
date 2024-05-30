using System.Web.Mvc;
using WebProject.Domain.Enum;
using WebProject.ModelAccessLayer.Model;
using WebProject.BusinessLogic.Interfaces;

namespace WebProject.Controllers
{
    public class AdminController : BaseController
    {
        // GET: AdminAddProduct
        public ActionResult NewProduct()
        {
            if (IsAdmin())
                return View();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ViewProducts()
        {
            if (IsAdmin())
            {
                ((UserData)Session["UserData"]).ProductsAdmin = (_businessLogic.User as IAdmin).GetAllProducts();
                return View((UserData)Session["UserData"]);
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ViewDelivery()
        {
            if (IsAdmin())
            {
                ((UserData)Session["UserData"]).DeliveriesUser = (_businessLogic.User as IAdmin).GetAllActiveOrder();
                return View((UserData)Session["UserData"]);
            }
            return RedirectToAction("Index", "Home");
        }

        // в бизнес логике обмен данными
        [HttpPost]
        public ActionResult NewProduct(Product product)
        {
            if (IsAdmin())
            {
                if (ModelState.IsValid)
                {
                    (_businessLogic.User as IAdmin).AddProduct(product);
                    return RedirectToAction("Index", "Home");
                }
                return View(product);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult EditProduct(int id)
        {
            if (IsAdmin())
                return View(_businessLogic.User.GetProductById(id));
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult ReplaceProduct(Product product)
        {
            if (IsAdmin())
            {
                if (ModelState.IsValid)
                {
                    (_businessLogic.User as IAdmin).EditProduct(product);
                    return RedirectToAction("ViewProducts", "Admin");
                }
                return RedirectToAction("EditProduct", "Admin", product.Id);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult DeleteProduct(int id)
        {
            if (IsAdmin())
            {
                (_businessLogic.User as IAdmin).DeleteProduct(id);
                return RedirectToAction("ViewProducts", "Admin");
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult DeleteDelivery(int id)
        {
            if (IsAdmin())
            {
                (_businessLogic.User as IAdmin).DeleteOrderModel(id);
                return RedirectToAction("ViewDelivery", "Admin");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}