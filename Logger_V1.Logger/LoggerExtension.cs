using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Logger_V1.Logger
{
    public static class LoggerExtension
    {
        public static IApplicationBuilder UseLoggerMiddleware(this IApplicationBuilder builder, IConfigurationRoot configuration)
        {
            return builder.UseMiddleware<LoggerMiddleware>();
        }

        public static ILoggerFactory AddLoggerService(this ILoggerFactory loggerFactory, IConfigurationRoot configuration)
        {
            loggerFactory.AddProvider(new LoggerProvider(configuration));


            //services.AddOptions();
            //services.Configure<MultiUserBlockSettings>(configuration.GetSection("MultiUserBlock"));

            //services.AddSingleton<IMultiUserBlockManager, MultiUserBlockManager>();
            //services.AddSingleton<IMultiUserBlockWebService, MultiUserBlockWebService>();
            return loggerFactory;
        }

        public static IServiceCollection AddLoggerService(this IServiceCollection services, IConfigurationRoot configuration)
        {
            //loggerFactory.AddProvider(new CustomLoggerProvider(new CustomLoggerConfiguration()));


            //services.AddOptions();
            //services.Configure<MultiUserBlockSettings>(configuration.GetSection("MultiUserBlock"));

            //services.AddSingleton<IMultiUserBlockManager, MultiUserBlockManager>();
            //services.AddSingleton<IMultiUserBlockWebService, MultiUserBlockWebService>();
            return services;
        }
    }
}

