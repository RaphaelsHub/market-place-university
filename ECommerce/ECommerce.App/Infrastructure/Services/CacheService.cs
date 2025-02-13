using System;
using System.Runtime.Caching;
using ECommerce.App.Infrastructure.Abstractions;

namespace ECommerce.App.Infrastructure.Services
{
    public class CacheService : ICacheService
    {
        private readonly ObjectCache _cache = MemoryCache.Default;

        public void SetCache(string key, object value, DateTimeOffset absoluteExpiration)
        {
            _cache.Set(key, value, absoluteExpiration);
        }

        public object GetCache(string key)
        {
            return _cache.Get(key);
        }

        public void RemoveCache(string key)
        {
            if (_cache.Contains(key))
            {
                _cache.Remove(key);
                _cache.Remove(key);
            }
        }
    }
}