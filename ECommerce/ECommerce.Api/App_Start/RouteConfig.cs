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
            
            RegisterAuthRoutes(routes);
            RegisterHomeRoutes(routes);
            
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }

        private static void RegisterHomeRoutes(RouteCollection routes)
        {
            routes.MapRoute(
                name: "ContactUsView",
                url: "contactUs",
                defaults: new { controller = "Home", action = "ContactUs" }
            );
            
            routes.MapRoute(
                name: "AboutUsView",
                url: "aboutUs",
                defaults: new { controller = "Home", action = "AboutUs" }
            );
            
            routes.MapRoute(
                name: "ConfirmationView",
                url: "confirmation",
                defaults: new { controller = "Home", action = "Confirmation" }
            );
            
            routes.MapRoute(
                name: "ErrorView",
                url: "error",
                defaults: new { controller = "Home", action = "Error" }
            );

            routes.MapRoute(
                name: "ErrorViewWithParams",
                url: "error/{errorCode}",
                defaults: new { controller = "Home", action = "Error", errorCode = UrlParameter.Optional}
            );


        }
        private static void RegisterAuthRoutes(RouteCollection routes)
        {
            routes.MapRoute(
                name: "SignInView",
                url: "signIn",
                defaults: new { controller = "Auth", action = "SignIn" }
            );
            
            routes.MapRoute(
                name: "SignUpView",
                url: "signUp",
                defaults: new { controller = "Auth", action = "SignUp" }
            );
            
            routes.MapRoute(
                name: "SignOutView",
                url: "signOut",
                defaults: new { controller = "Auth", action = "SignOut" }
            );
        }
    }
}