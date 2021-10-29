namespace Clean14000716.Common.Utilities
{
    public static class CacheKeyManager
    {
        public static string GetCacheKey(string apiName)
        {
            return apiName;
        }
        public static string GetCacheKey(string apiName, string args)
        {
            return  apiName + "_" + args;
        }
    }
}