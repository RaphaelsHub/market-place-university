using System;
using System.Threading.Tasks;
using System.Web;
using ECommerce.App.Infrastructure.Abstractions;

namespace ECommerce.App.Infrastructure.Services
{
    public class CookiesService : ICookiesService
    {
        public Task SetCookie(string key, string value, DateTime expires)
        {
            var cookie = new HttpCookie(key, value)
            {
                HttpOnly = true,
                Secure = true,
                Expires = expires
            };
            HttpContext.Current.Response.Cookies.Add(cookie);
            
            return Task.CompletedTask;
        }

        public Task<string> GetCookie(string key)
        {
            var cookie = HttpContext.Current.Request.Cookies[key];
            return cookie?.Value != null ? Task.FromResult(cookie.Value) : Task.FromResult(string.Empty);
        }

        public Task DeleteCookie(string key)
        {
            if (HttpContext.Current.Request.Cookies[key] != null)
            {
                var cookie = new HttpCookie(key)
                {
                    Expires = DateTime.Now.AddDays(-1)
                };
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
            
            return Task.CompletedTask;
        }
    }
}