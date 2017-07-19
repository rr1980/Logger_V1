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

        //public static ILoggerFactory AddLoggerProvider(this ILoggerFactory loggerFactory, IConfigurationRoot configuration)
        //{
        //    loggerFactory.AddProvider(new LoggerProvider(configuration));
            

        //    //services.AddOptions();
        //    //services.Configure<MultiUserBlockSettings>(configuration.GetSection("MultiUserBlock"));

        //    //services.AddSingleton<IMultiUserBlockManager, MultiUserBlockManager>();
        //    //services.AddSingleton<IMultiUserBlockWebService, MultiUserBlockWebService>();
        //    return loggerFactory;
        //}

        //public static IServiceCollection AddLoggerService(this IServiceCollection services, IConfigurationRoot configuration)
        //{
        //    //loggerFactory.AddProvider(new CustomLoggerProvider(new CustomLoggerConfiguration()));


        //    //services.AddOptions();
        //    //services.Configure<MultiUserBlockSettings>(configuration.GetSection("MultiUserBlock"));

        //    //services.AddSingleton<IMultiUserBlockManager, MultiUserBlockManager>();
        //    //services.AddSingleton<IMultiUserBlockWebService, MultiUserBlockWebService>();
        //    return services;
        //}
    }
}

