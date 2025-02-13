using System;

namespace ECommerce.App.Infrastructure.Abstractions
{
    public interface ICacheService
    {
        void SetCache(string key, object value, DateTimeOffset absoluteExpiration);
        object GetCache(string key);
        void RemoveCache(string key);
    }
}