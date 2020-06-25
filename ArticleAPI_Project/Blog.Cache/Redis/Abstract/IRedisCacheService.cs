using System;
using System.Collections.Generic;

namespace Blog.Cache.Redis.Abstract
{
    public interface IRedisCacheService
    {
        List<T> GetList<T>(string cachekey);
        T Get<T>(string cachekey);
        void Set<T>(string cachekey, object value, TimeSpan time);
        bool ContainsKey(string cachekey);
        void Clear<T>(string cachekey);
    }
}