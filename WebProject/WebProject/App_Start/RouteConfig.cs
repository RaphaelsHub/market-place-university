using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebProject
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ThanksManagement",
                url: "Home/{action}/{id}",
                defaults: new { controller = "Home", action = "ThanksForOrder", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "CartManagement",
                url: "Cart/{action}/{id}",
                defaults: new { controller = "Cart", action = "Buy", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "SignIn",
                url: "SignIn/{action}/{id}",
                defaults: new { controller = "SignIn", action = "Login", id = UrlParameter.Optional }
             );

            routes.MapRoute(
                name: "SignUp",
                url: "SignUp/{action}/{id}",
                defaults: new { controller = "SignUp", action = "Registration", id = UrlParameter.Optional }
            );


            routes.MapRoute(
                 name: "ProductItem",
                url: "Product/Item/{id}",
                defaults: new { controller = "Product", action = "Item", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Categories",
                url: "Categories/{action}/{id}",
                defaults: new { controller = "Categories", action = "Items", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "Order",
               url: "Order/{action}/{id}",
               defaults: new { controller = "Order", action = "MakeAnOrder", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "AllProducts",
               url: "AllProducts/{action}/{id}",
               defaults: new { controller = "AdminAllProducts", action = "ViewProducts", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "AddAProduct",
               url: "AddAProduct/{action}/{id}",
               defaults: new { controller = "AdminAddProduct", action = "NewProduct", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "Delivery",
               url: "Delivery/{action}/{id}",
               defaults: new { controller = "AdminDelivery", action = "EditDelivery", id = UrlParameter.Optional }
            );
        }
    }
}
