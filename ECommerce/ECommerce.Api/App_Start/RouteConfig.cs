using System.Web.Mvc;
using System.Web.Routing;

namespace ECommerce
{
    public class RouteConfig
    {
        // Adding custom routes before the default route is important
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Auth routes
            routes.MapRoute(
                name: "SignInView",
                url: "signin",
                defaults: new { controller = "Auth", action = "SignIn" }
            );
            
            routes.MapRoute(
                name: "SignUpView",
                url: "signup",
                defaults: new { controller = "Auth", action = "SignUp" }
            );
            
            // Home routes
            routes.MapRoute(
                name: "ContactUsView",
                url: "contactus",
                defaults: new { controller = "Home", action = "ContactUs" }
            );
            
            routes.MapRoute(
                name: "AboutUsView",
                url: "about",
                defaults: new { controller = "Home", action = "AboutUs" }
            );
            
            routes.MapRoute(
                name: "ConfirmationView",
                url: "confirmation",
                defaults: new { controller = "Home", action = "Confirmation" }
            );
            
            routes.MapRoute(
                name: "ErrorView",
                url: "error/{errorCode}/{errorMessage}",
                defaults: new { controller = "Home", action = "Error", errorCode = UrlParameter.Optional, errorMessage = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );



        }
    }
}