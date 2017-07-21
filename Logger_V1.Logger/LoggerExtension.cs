using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Logger_V1.Logger
{
    public static class LoggerExtension
    {
        public static IApplicationBuilder UseLoggerMiddleware(this IApplicationBuilder app, IConfigurationRoot configuration)
        {
            var loggerFactory = app.ApplicationServices.GetService<ILoggerFactory>();
            loggerFactory.AddProvider(new LoggerProvider(configuration));


            return app.UseMiddleware<LoggerMiddleware>(loggerFactory);
        }

        public static IServiceCollection AddLoggerService(this IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddSingleton(new LoggerService(configuration));
            return services;
        }
    }
}

