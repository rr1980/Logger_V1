using Logger_V1.Logger.Interfaces;
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
            var loggerService = app.ApplicationServices.GetService<ILoggerService>();
            loggerFactory.AddProvider(new LoggerProvider(loggerService, configuration));

            return app.UseMiddleware<LoggerMiddleware>(loggerService);
        }

        public static IServiceCollection AddLoggerService(this IServiceCollection services,IMvcBuilder builder, IConfigurationRoot configuration)
        {
            var ls = new LoggerService(configuration);
            services.AddSingleton<ILoggerService>(ls);
            builder.AddMvcOptions(o => { o.Filters.Add(new LoggerWrapper(ls, "Exception", configuration)); });

            return services;
        }
    }
}