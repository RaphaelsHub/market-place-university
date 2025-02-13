using System;
using System.Threading.Tasks;

namespace ECommerce.App.Infrastructure.Abstractions
{
    public interface ICookiesService
    {
        Task SetCookie(string key, string value, DateTime expires);
        Task<string> GetCookie(string key);
        Task DeleteCookie(string key);
    }
}