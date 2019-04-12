using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using NetCoreLearn.Core.MemoryLearn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreLearn.Controllers
{
    /// <summary>
    /// 缓存模块
    /// </summary>
    public class MemoryController : Controller
    {
        private MemoryCache _cache;

        public static readonly string MyKey = "_MyKey";

        public MemoryController(MyMemoryCache memoryCache)
        {
            _cache = memoryCache.Cache;
        }

        /// <summary>
        /// tempdata在页面跳转时也会一直存在
        /// </summary>
        [TempData]
        public string DateTime_Now { get; set; }

        public IActionResult Index()
        {
            OnGet();
            return View();
        }

        public void OnGet()
        {
            if (!_cache.TryGetValue(MyKey, out string cacheEntry))
            {
                // Key not in cache, so get data.
                cacheEntry = DateTime.Now.TimeOfDay.ToString();

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Set cache entry size by extension method.
                    .SetSize(1)
                    // Keep in cache for this time, reset time if accessed.
                    .SetSlidingExpiration(TimeSpan.FromSeconds(3));

                // Set cache entry size via property.
                // cacheEntryOptions.Size = 1;

                // Save data in cache.
                _cache.Set(MyKey, cacheEntry, cacheEntryOptions);
            }

            DateTime_Now = cacheEntry;
        }
    }
}