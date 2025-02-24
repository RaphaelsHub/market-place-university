using System.Web.Mvc;
using System.Web.Routing;

namespace ECommerce
{
    public class RouteConfig
    {
        // Добавление пользовательских маршрутов перед маршрутами по умолчанию важно
        public static void ConfigureRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // admin маршруты
            AddAdminBlogRoutes(routes);
            AddAdminOrderRoutes(routes);
            AddAdminProductRoutes(routes);
            AddAdminUserRoutes(routes);
            AddAdminSiteDataRoutes(routes);
            
            // пользовательские маршруты
            AddCartRoutes(routes);
            AddNewsRoutes(routes);
            AddOrderRoutes(routes);
            AddStoreRoutes(routes);
            AddAuthRoutes(routes);
            AddHomeRoutes(routes);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }



        private static void AddAdminBlogRoutes(RouteCollection routes)
        {
            routes.MapRoute(
                name: "ViewAllBlogs_Admin",
                url: "admin/blogs",
                defaults: new { controller = "ManagementBlogs", action = "Index" }
            );

            routes.MapRoute(
                name: "ViewSingleBlog_Admin",
                url: "admin/blogs/{id}",
                defaults: new { controller = "ManagementBlogs", action = "ViewBlog" }
            );
        }

        private static void AddAdminOrderRoutes(RouteCollection routes)
        {
            routes.MapRoute(
                name: "ViewAllOrders_Admin",
                url: "admin/orders",
                defaults: new { controller = "ManagementOrders", action = "Index" }
            );
        
            routes.MapRoute(
                name: "ViewSingleOrder_Admin",
                url: "admin/orders/{id}",
                defaults: new { controller = "ManagementOrders", action = "ViewOrder" }
            );
        }
        
        private static void AddAdminProductRoutes(RouteCollection routes)
        {
            routes.MapRoute(
                name: "ViewAllProducts_Admin",
                url: "admin/products",
                defaults: new { controller = "ManagementProducts", action = "Index" }
            );
        
            routes.MapRoute(
                name: "ViewSingleProduct_Admin",
                url: "admin/products/{id}",
                defaults: new { controller = "ManagementProducts", action = "ViewProduct" }
            );
        }
        
        private static void AddAdminSiteDataRoutes(RouteCollection routes)
        {
            routes.MapRoute(
                name: "ViewSiteData_Admin",
                url: "admin/web",
                defaults: new { controller = "ManagementWebSiteData", action = "Index" }
            );
            
            routes.MapRoute(
                name: "ViewContactUs_Admin",
                url: "admin/contactus",
                defaults: new { controller = "ManagementWebSiteData", action = "ContactUs" }
            );
        }
        
        private static void AddAdminUserRoutes(RouteCollection routes)
        {
            routes.MapRoute(
                name: "ViewAllUsers_Admin",
                url: "admin/users",
                defaults: new { controller = "ManagementUsers", action = "Index"}
            );

            routes.MapRoute(
                name: "ViewSingleUser_Admin",
                url: "admin/users/{id}",
                defaults: new { controller = "ManagementUsers", action = "ViewUser" }
            );
        }

        private static void AddCartRoutes(RouteCollection routes)
        {
            routes.MapRoute(
                name: "ViewCart",
                url: "cart",
                defaults: new { controller = "Cart", action = "Index" }
            );
        }

        private static void AddNewsRoutes(RouteCollection routes)
        {
            routes.MapRoute(
                name: "ViewAllBlogs",
                url: "news",
                defaults: new { controller = "News", action = "Index" }
            );

            routes.MapRoute(
                name: "ViewSingleBlog",
                url: "news/{id}",
                defaults: new { controller = "News", action = "Blog", id = UrlParameter.Optional }
            );
        }

        private static void AddOrderRoutes(RouteCollection routes)
        {
            routes.MapRoute(
                name: "ViewAllOrders",
                url: "orders",
                defaults: new { controller = "Orders", action = "Index" }
            );

            routes.MapRoute(
                name: "ViewOrderDetails",
                url: "orders/{id}",
                defaults: new { controller = "Orders", action = "OrderDetails", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "OrderDataForm",
                url: "make-order",
                defaults: new { controller = "Orders", action = "OrderDataForm" }
            );
        }

        private static void AddStoreRoutes(RouteCollection routes)
        {
            routes.MapRoute(
                name: "ViewAllProducts",
                url: "products",
                defaults: new { controller = "Store", action = "Index" }
            );

            routes.MapRoute(
                name: "ViewSingleProduct",
                url: "products/{id}",
                defaults: new { controller = "Store", action = "Product", id = UrlParameter.Optional }
            );
        }

        private static void AddHomeRoutes(RouteCollection routes)
        {
            routes.MapRoute(
                name: "ContactUs",
                url: "contactUs",
                defaults: new { controller = "Home", action = "ContactUs" }
            );

            routes.MapRoute(
                name: "AboutUs",
                url: "aboutUs",
                defaults: new { controller = "Home", action = "AboutUs" }
            );

            routes.MapRoute(
                name: "Confirmation",
                url: "confirmation",
                defaults: new { controller = "Home", action = "Confirmation" }
            );

            routes.MapRoute(
                name: "Error",
                url: "error",
                defaults: new { controller = "Home", action = "Error" }
            );

            routes.MapRoute(
                name: "ErrorWithParams",
                url: "error/{errorCode}",
                defaults: new { controller = "Home", action = "Error", errorCode = UrlParameter.Optional }
            );
        }

        private static void AddAuthRoutes(RouteCollection routes)
        {
            routes.MapRoute(
                name: "SignIn",
                url: "signIn",
                defaults: new { controller = "Auth", action = "SignIn" }
            );

            routes.MapRoute(
                name: "SignUp",
                url: "signUp",
                defaults: new { controller = "Auth", action = "SignUp" }
            );

            routes.MapRoute(
                name: "SignOut",
                url: "signOut",
                defaults: new { controller = "Auth", action = "SignOut" }
            );
        }
    }
}
