using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ECommerce.App.Interfaces;
using ECommerce.App.Services;
using ECommerce.Controllers;
using ECommerce.Core.Entities.Blog;
using ECommerce.Core.Entities.Product;
using ECommerce.Core.Entities.User;
using ECommerce.Core.Interfaces.Admin;
using ECommerce.Core.Interfaces.Blog;
using ECommerce.Core.Interfaces.Product;
using ECommerce.Core.Interfaces.User;
using ECommerce.Dal;
using ECommerce.Dal.Repositories.Admin;
using ECommerce.Dal.Repositories.Blog;
using ECommerce.Dal.Repositories.Product;
using ECommerce.Dal.Repositories.User;
using ECommerce.Helper;
using Unity;
using Unity.AspNet.Mvc;

namespace ECommerce
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            var container = new UnityContainer();
            RegisterTypes(container);
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
                private void RegisterTypes(UnityContainer container)
        {
            // Регистрация зависимостей среди сервисов
            container.RegisterType<IAuthService, AuthService>();
            container.RegisterType<IAdminService, AdminService>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<IOrderService, OrderService>();
            container.RegisterType<IBlogService, BlogService>();
            container.RegisterType<ICartService, CartService>();
            container.RegisterType<ILogErrorService, LogErrorsService>();
            
            // Регистрация зависимостей среди репозиториев
            // User
            container.RegisterType<IUsersRepository<UserEf>, UsersRepository>();
            container.RegisterType<IOrdersRepository<OrderEf>, OrdersRepository>();
            container.RegisterType<IOrderItemsRepository<OrderItemEf>,OrderItemsRepository>();
            container.RegisterType<ICartItemsRepository<CartItemEf>,CartItemsRepository>();
            container.RegisterType<IAddressesRepository<AddressEf>,AddressesRepository>();
            container.RegisterType<IContactUsRepository<ContactUsEf>, ContactUsRepository>();
            
            // Product
            container.RegisterType<IProductsRepository<ProductEf>, ProductsRepository>();
            container.RegisterType<ICategoriesRepository<CategoryEf>, CategoriesRepository>();
            container.RegisterType<IFiltersRepository<FilterEf>,FiltersRepository>();
            container.RegisterType<IFilterValuesRepository<FilterValueEf>,FilterValuesRepository>();
            container.RegisterType<IRateItemsRepository<RateItemEf>,RateItemsRepository>();
            
            // Blog
            container.RegisterType<IBlogsRepository<BlogEf>, BlogsRepository>();
            container.RegisterType<IMessagesRepository<MessageEf>,MessagesRepository>();
            
            // WebSite
            container.RegisterType<IWebSiteControl,WebSiteControl>();
            
            // Регистрация контекста базы данных
            container.RegisterType<StoreContext>();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();
            var httpException = exception as HttpException;
        
            Server.ClearError();
        
            var routeData = ErrorHelper.GetRouteData(httpException);
            
            IController homeController = new HomeController();
            var contextWrapper = new HttpContextWrapper(Context);
            var requestContext = new RequestContext(contextWrapper, routeData);
            homeController.Execute(requestContext);
        }
    }
}