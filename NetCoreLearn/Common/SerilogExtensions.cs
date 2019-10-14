using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreLearn.Common
{
    public static class SerilogExtensions
    {
        public static IServiceCollection AddSerilogTool(this IServiceCollection services)
        {
            services.AddSingleton<Logger>((provider) =>
            {
                return new LoggerConfiguration()
                            .WriteTo.Console()
                            .WriteTo.File("log-.txt", rollingInterval: RollingInterval.Day)
                            .CreateLogger();
            });
            return services;
        }
    }
}
