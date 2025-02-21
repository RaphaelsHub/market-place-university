using System;

namespace ECommerce.App.Infrastructure.Abstractions
{
    public interface ICookiesService
    {
        void SetCookie(string key, string value, DateTime expires);
        string GetCookie(string key);
        void DeleteCookie(string key);
    }
}

