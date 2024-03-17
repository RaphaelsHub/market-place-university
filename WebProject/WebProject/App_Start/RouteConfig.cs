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
                name: "Product",
                url: "Product/{action}/{id}",
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
               name: "Admin",
               url: "Admin/{action}/{id}",
               defaults: new { controller = "AdminViewProducts", action = "ViewProducts", id = UrlParameter.Optional }
            );
        }
    }
}
