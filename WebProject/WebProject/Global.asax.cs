using System;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Unity;
using Unity.AspNet.Mvc;
using WebProject.App.Interfaces;
using WebProject.App.Services;
using WebProject.Controllers;
using WebProject.Core.Entities.Blog;
using WebProject.Core.Entities.Product;
using WebProject.Core.Entities.User;
using WebProject.Core.Interfaces.Blog;
using WebProject.Core.Interfaces.Product;
using WebProject.Core.Interfaces.User;
using WebProject.Dal;
using WebProject.Dal.Repositories.Blog;
using WebProject.Dal.Repositories.Product;
using WebProject.Dal.Repositories.User;

namespace WebProject
{
    public class Global : HttpApplication
    {
        // Метод регистрации зависимостей
        void Application_Start(object sender, EventArgs e)
        { 
            // Код, выполняемый при запуске приложения
           AreaRegistration.RegisterAllAreas();
           
           // Конфигурация маршрутов
           RouteConfig.RegisterRoutes(RouteTable.Routes);
           
           // Конфигурация бандлов
           //BundleConfig.RegisterBundles(BundleTable.Bundles);// using System.Web.Optimization - need to install
          
           // Инициализация базы данных
           Database.SetInitializer(new CreateDatabaseIfNotExists<StoreContext>());
           
           // 
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
            
            // Регистрация контекста базы данных
            container.RegisterType<StoreContext>();
        }

        // Метод обработки ошибок
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
