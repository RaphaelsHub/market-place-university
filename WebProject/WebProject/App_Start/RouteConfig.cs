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
                name: "Store",
                url: "product/{id}",
                defaults: new { controller = "Store", action = "Product", id = UrlParameter.Optional }
                );
            
            routes.MapRoute(
                name: "Store",
                url: "products",
                defaults: new { controller = "Store", action = "Products" }
                );

        }
    }
}
