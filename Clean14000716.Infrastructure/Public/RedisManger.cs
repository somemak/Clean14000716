using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Clean14000716.Application;
using Clean14000716.Application.Common.Interfaces.Public;
using Clean14000716.Application.Common.Mapping;
using Clean14000716.Common.ForAutofacMark;
using Clean14000716.Common.Utilities;
using Clean14000716.Domain.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ServiceStack.Redis;

namespace Clean14000716.Infrastructure.Public
{
    public class RedisManger : IRedisManager, ISingletonDependency
    {
        private readonly IDistributedCache _cache;
        private readonly HashSet<string> _keys;

        public RedisManger(IDistributedCache cache)
        {
            //_cache = cache;
            //using var client = new RedisClient("localhost", 6379);
            //var res = client.Custom(Commands.Keys, "*");
            //_keys = res.Children.Select(text => text.Text).ToHashSet();
        }

        public async Task Create<T>(string key, T data, TimeSpan? exTime = null, TimeSpan? unUseExTime = null)
        {
            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = exTime,
                SlidingExpiration = unUseExTime
            };

            var jsonData = JsonConvert.SerializeObject(data);
            var zipData = GZipHelper.Zip(jsonData);
            await _cache.SetAsync(key, zipData, options);
            //key = Path.GetFileNameWithoutExtension(System.Diagnostics.Process.GetCurrentProcess().MainModule?.FileName) + "_" + key;
            _keys.Add(key);
        }

        public async Task<T> Get<T>(string key)
        {
            string jsonData = null;
            var zippedJsonData = await _cache.GetAsync(key);

            if (zippedJsonData is not null)
                jsonData = GZipHelper.Unzip(zippedJsonData);

            return jsonData is null ? default : JsonConvert.DeserializeObject<T>(jsonData);
        }

        public async Task DeleteKeysForRequest(string requestContains)
        {
            requestContains += "Query";
             
             var deletedKeys = _keys.Where(s => s.Contains(requestContains)).AsEnumerable();

            foreach (var deletedKey in deletedKeys)
            {
                await _cache.RemoveAsync(deletedKey);
            }
            _keys.RemoveWhere(s => s.Contains(requestContains));











        }
    }
}