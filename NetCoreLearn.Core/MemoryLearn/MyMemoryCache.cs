using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Caching.Memory;

namespace NetCoreLearn.Core.MemoryLearn
{
    public class MyMemoryCache
    {
        public MemoryCache Cache { get; set; }

        public MyMemoryCache()
        {
            Cache = new MemoryCache(new MemoryCacheOptions
            {
                SizeLimit = 1024
            });
        }
    }
}