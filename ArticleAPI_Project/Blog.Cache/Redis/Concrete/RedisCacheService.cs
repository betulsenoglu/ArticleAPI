using System;
using System.Collections.Generic;
using Blog.Cache.Redis.Abstract;
using ServiceStack.Redis;

namespace Blog.Cache.Redis.Concrete
{
    public class RedisCacheService : IRedisCacheService
    {
        public List<T> GetList<T>(string cachekey)
        {
            using (IRedisClient client = new RedisClient())
            {
                try
                {
                    return client.Get<List<T>>(cachekey);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Something went wrong when getting datalist in GetList<T> method:" + e);
                    return null;
                }
            }
        }

        public T Get<T>(string cachekey)
        {
            using (IRedisClient client = new RedisClient())
            {
                var redisdata = client.Get<T>(cachekey);

                return redisdata;
            }
        }

        public void Set<T>(string cachekey, object value, TimeSpan time)
        {
            using (IRedisClient client = new RedisClient())
            {
                client.Set(cachekey, value, time);
            }
        }

        public void Remove<T>(string cachekey)
        {
            using (IRedisClient client = new RedisClient())
            {
                client.Remove(cachekey);
            }
        }

        public bool ContainsKey(string cachekey)
        {
            using (IRedisClient client = new RedisClient())
            {
                return client.ContainsKey(cachekey);
            }
        }

        public void Clear<T>(string cachekey)
        {
            if (ContainsKey(cachekey))
            {
                using (IRedisClient client = new RedisClient())
                {
                    client.ContainsKey(cachekey);
                }
            }
        }
    }
}