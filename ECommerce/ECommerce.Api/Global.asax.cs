using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ECommerce.App.Infrastructure.Abstractions;
using ECommerce.App.Infrastructure.Services;
using ECommerce.App.Interfaces.Admin;
using ECommerce.App.Interfaces.Auth;
using ECommerce.App.Interfaces.Blog;
using ECommerce.App.Interfaces.JWT;
using ECommerce.App.Interfaces.Product;
using ECommerce.App.Interfaces.User;
using ECommerce.App.Services.Admin;
using ECommerce.App.Services.Auth;
using ECommerce.App.Services.Blog;
using ECommerce.App.Services.JWT;
using ECommerce.App.Services.Product;
using ECommerce.App.Services.User;
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
            
            // ConfigureJwtAuth();      
        }

        // private void ConfigureJwtAuth()
        // {
        //     throw new NotImplementedException();
        // }

        private void RegisterTypes(UnityContainer container)
        {
            // Регистрация зависимостей среди сервисов
            // auth
            container.RegisterType<IAccountManagementService, AccountManagementService>();
            container.RegisterType<IAuthenticationService, AuthenticationService>();
            container.RegisterType<IAuthorizationService, AuthorizationService>();
            // admin
            container.RegisterType<IAdminService, AdminService>();
            // user
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IOrderService, OrderService>();
            container.RegisterType<ICartService, CartService>();
            // product
            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<ICategoryService, CategoryService>();
            // blog
            container.RegisterType<IBlogService, BlogService>();

            container.RegisterType<ICookiesService, CookiesService>();
            container.RegisterType<IJwtService, JwtService>();
            container.RegisterType<IContactUsService, ContactUsService>();
            
            // Регистрация зависимостей среди репозиториев
            // User
            container.RegisterType<IUsersRepository, UsersRepository>();
            container.RegisterType<IOrdersRepository<OrderEf>, OrdersRepository>();
            container.RegisterType<IOrderItemsRepository<OrderItemEf>,OrderItemsRepository>();
            container.RegisterType<ICartItemsRepository<CartItemEf>,CartItemsRepository>();
            container.RegisterType<IAddressesRepository<AddressEf>,AddressesRepository>();
            container.RegisterType<IContactUsRepository, ContactUsRepository>();
            
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
            
            //
            // IController homeController = DependencyResolver.Current.GetService<HomeController>();
            //
            // // var container = DependencyResolver.Current.GetService<IUnityContainer>();
            // // IController homeController = container.Resolve<HomeController>();
            
            var contextWrapper = new HttpContextWrapper(Context);
            var requestContext = new RequestContext(contextWrapper, routeData);
            homeController.Execute(requestContext);
        }
    }
}