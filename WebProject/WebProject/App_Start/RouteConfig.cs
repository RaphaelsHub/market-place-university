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
                name: "Error404Management",
                url: "Home/{action}/{id}",
                defaults: new { controller = "Home", action = "Error404", id = UrlParameter.Optional }
            );            
            
            routes.MapRoute(
                name: "SearchManagement",
                url: "Home/{action}/{id}",
                defaults: new { controller = "Home", action = "Search", id = UrlParameter.Optional }
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
               name: "DeliveryManagement",
                url: "Delivery/{action}/{id}",
                defaults: new { controller = "Cart", action = "Delivery", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "LoginManagement",
                url: "Accaunt/{action}/{id}",
                defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }
             );

            routes.MapRoute(
                name: "RegistrationManagement",
                url: "Accaunt/{action}/{id}",
                defaults: new { controller = "Account", action = "Registration", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                 name: "ProductItem",
                url: "Catalog/Item/{id}",
                defaults: new { controller = "Catalog", action = "Item", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Categories",
                url: "Catalog/{action}/{id}/{id1}",
                defaults: new { controller = "Catalog", action = "Items", id = UrlParameter.Optional, id1=UrlParameter.Optional }
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
               defaults: new { controller = "Admin", action = "ViewDelivery", id = UrlParameter.Optional }
            );
        }
    }
}
