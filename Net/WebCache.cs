using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Caching;
using System.Collections;

namespace J7.Net
{
    /// <summary>
    /// 应用级缓存帮助类
    /// </summary>
    public class WebCache
    {
        /// <summary>
        /// 获取数据缓存
        /// </summary>
        /// <param name="cache_key">键</param>
        public static object GetCache(string cache_key)
        {
            Cache objCache = HttpRuntime.Cache;
            return objCache[cache_key];
        }

        /// <summary>
        /// 设置数据缓存
        /// </summary>
        public static void SetCache(string cache_key, object objObject)
        {
            Cache objCache = HttpRuntime.Cache;
            objCache.Insert(cache_key, objObject);
        }

        /// <summary>
        /// 设置数据缓存
        /// <param name="cache_key">缓存KEY</param>
        /// <param name="objObject">缓存对象</param>
        /// <param name="second">缓存时间，以秒为单位</param>
        /// </summary>
        public static void SetCache(string cache_key, object objObject, int second)
        {
            Cache objCache = HttpRuntime.Cache;
            objCache.Insert(cache_key, objObject, null, DateTime.UtcNow.AddSeconds(second), Cache.NoSlidingExpiration, CacheItemPriority.NotRemovable, null);
        }

        /// <summary>
        /// 设置数据缓存
        /// </summary>
        public static void SetCache(string cache_key, object objObject, DateTime absoluteExpiration, TimeSpan slidingExpiration)
        {
            Cache objCache = HttpRuntime.Cache;
            objCache.Insert(cache_key, objObject, null, absoluteExpiration, slidingExpiration);
        }

        /// <summary>
        /// 移除指定数据缓存
        /// </summary>
        public static void RemoveCache(string cache_key)
        {
            Cache _cache = HttpRuntime.Cache;
            _cache.Remove(cache_key);
        }

        /// <summary>
        /// 移除全部缓存
        /// </summary>
        public static void RemoveAllCache()
        {
            Cache _cache = HttpRuntime.Cache;
            IDictionaryEnumerator CacheEnum = _cache.GetEnumerator();
            while (CacheEnum.MoveNext())
            {
                _cache.Remove(CacheEnum.Key.ToString());
            }
        }
    }
}
