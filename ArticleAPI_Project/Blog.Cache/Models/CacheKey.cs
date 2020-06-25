namespace Blog.Cache.Models
{
    public static class CacheKey
    {
        public static int DefaultExpiration = 1000; //sec
        public static string BlogCacheKey = "blog.*";
    }
}