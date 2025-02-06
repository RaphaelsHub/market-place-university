using System;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebProject.Controllers;

namespace WebProject
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        { 
            // Code that runs on application startup
           AreaRegistration.RegisterAllAreas();
           RouteConfig.RegisterRoutes(RouteTable.Routes);
           //BundleConfig.RegisterBundles(BundleTable.Bundles);// Bundle config registration ﻿using System.Web.Optimization - need to install
        }
        
        protected void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();
            var httpException = exception as HttpException;

            Server.ClearError();

            var routeData = new RouteData
            {
                Values =
                {
                    ["controller"] = "Home",
                    ["action"] = "Error",
                    // Передача кода ошибки
                    ["statusCode"] = httpException?.GetHttpCode() ?? 500
                }
            };

            // Вызов контроллера и действия
            IController homeController = new HomeController();
            var contextWrapper = new HttpContextWrapper(Context);
            var requestContext = new RequestContext(contextWrapper, routeData);
            homeController.Execute(requestContext);
        }
    }
}
