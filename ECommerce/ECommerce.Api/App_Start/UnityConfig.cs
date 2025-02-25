using System;
using ECommerce.App.Infrastructure.Abstractions;
using ECommerce.App.Infrastructure.Services;
using ECommerce.App.Interfaces.Blog;
using ECommerce.App.Interfaces.JWT;
using ECommerce.App.Interfaces.Product;
using ECommerce.App.Interfaces.User;
using ECommerce.App.Services.Blog;
using ECommerce.App.Services.JWT;
using ECommerce.App.Services.Product;
using ECommerce.App.Services.User;
using ECommerce.Core.Interfaces.Blog;
using ECommerce.Core.Interfaces.Product;
using ECommerce.Core.Interfaces.User;
using ECommerce.Dal;
using ECommerce.Dal.Repositories.Blog;
using ECommerce.Dal.Repositories.Product;
using ECommerce.Dal.Repositories.User;
using Unity;

namespace ECommerce 
{
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> _container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });
        
        public static IUnityContainer Container => _container.Value;
        #endregion
        
        
        public static void RegisterTypes(IUnityContainer container)
        {
            /*
             * NOTE: To load from web.config uncomment the line below.
             * Make sure to add a Unity.Configuration to the using statements.
             *container.LoadConfiguration();
             */
            
            RegisterDbContext(container);
            RegisterRepositories(container);
            RegisterServices(container);
        }

        private static void RegisterServices(IUnityContainer container)
        {
            //bll
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IOrderService, OrderService>();
            container.RegisterType<ICartService, CartService>();
            container.RegisterType<IContactUsService, ContactUsService>();
            container.RegisterType<IAuthenticationService, AuthenticationService>();
            container.RegisterType<IJwtService, JwtService>();
            container.RegisterType<ICategoryService, CategoryService>();
            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<IBlogService, BlogService>();
            
            //infrastructure
            container.RegisterType<ICookiesService, CookiesService>();
            container.RegisterType<ICacheService, CacheService>();
            container.RegisterType<ISessionService, SessionService>();
        }

        private static void RegisterRepositories(IUnityContainer container)
        {
            container.RegisterType<IUsersRepository, UsersRepository>();
            container.RegisterType<IOrdersRepository, OrdersRepository>();
            container.RegisterType<ICartRepository, CartRepository>();
            container.RegisterType<IContactUsRepository, ContactUsRepository>();
            
            container.RegisterType<IProductsRepository, ProductsRepository>();
            container.RegisterType<ICategoriesRepository, CategoriesRepository>();
            container.RegisterType<IFiltersRepository, FiltersRepository>();
            container.RegisterType<IFilterValuesRepository, FilterValuesRepository>();
            
            container.RegisterType<IBlogsRepository, BlogsRepository>();
            container.RegisterType<IMessagesRepository, MessagesRepository>();
        }

        private static void RegisterDbContext(IUnityContainer container)
        {
            container.RegisterType<StoreContext>();
        }
    }
}