using Unity;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;

namespace ECommerce
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.ConfigureRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            MappingConfig.RegisterMappings();
            UnityConfig.RegisterTypes(new UnityContainer());
        }
        
        // protected void Application_Error(object sender, EventArgs e)
        // {
        //     var exception = Server.GetLastError();
        //     var httpException = exception as HttpException;
        //
        //     Server.ClearError();
        //
        //     var routeData = ErrorHelper.GetRouteData(httpException);
        //     
        //     IController homeController = new HomeController();
        //     
        //     //
        //     // IController homeController = DependencyResolver.Current.GetService<HomeController>();
        //     //
        //     // // var container = DependencyResolver.Current.GetService<IUnityContainer>();
        //     // // IController homeController = container.Resolve<HomeController>();
        //     
        //     var contextWrapper = new HttpContextWrapper(Context);
        //     var requestContext = new RequestContext(contextWrapper, routeData);
        //     homeController.Execute(requestContext);
        // }
    }
}