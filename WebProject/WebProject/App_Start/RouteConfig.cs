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
                name: "ErrorManagement",
                url: "Home/{action}/{id}",
                defaults: new { controller = "Home", action = "Error", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "CartManagement",
                url: "Cart/{action}/{id}",
                defaults: new { controller = "Cart", action = "Buy", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "OrderManagement",
               url: "Cart/{action}/{id}",
               defaults: new { controller = "Cart", action = "MakeAnOrder", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "LoginManagement",
                url: "Accaunt/{action}/{id}",
                defaults: new { controller = "Accaunt", action = "Login", id = UrlParameter.Optional }
             );

            routes.MapRoute(
                name: "RegistrationManagement",
                url: "Accaunt/{action}/{id}",
                defaults: new { controller = "Accaunt", action = "Registration", id = UrlParameter.Optional }
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
               name: "AllProducts",
               url: "Admin/{action}/{id}",
               defaults: new { controller = "Admin", action = "ViewProducts", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "AddAProduct",
               url: "Admin/{action}/{id}",
               defaults: new { controller = "Admin", action = "NewProduct", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "Delivery",
               url: "Admin/{action}/{id}",
               defaults: new { controller = "Admin", action = "EditDelivery", id = UrlParameter.Optional }
            );
        }
    }
}
