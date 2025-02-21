using System.Web;
using ECommerce.App.Infrastructure.Abstractions;

namespace ECommerce.App.Infrastructure.Services
{
    public class SessionService : ISessionService
    {
        public void SetSessionValue(string key, string value) => 
            HttpContext.Current.Session[key] = value;
        
        public string GetSessionValue(string key) => 
            HttpContext.Current.Session[key]?.ToString();
        
        public void RemoveSessionValue(string key) => 
            HttpContext.Current.Session.Remove(key);
    }
}