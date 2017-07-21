using Microsoft.Extensions.Configuration;
using System.Collections.Concurrent;

namespace Logger_V1.Logger
{
    public class LoggerService
    {
        private IConfigurationRoot _configuration;

        public LoggerService(IConfigurationRoot configuration)
        {
            _configuration = configuration;
        }

        public ILogger_V1<T> CreateLogger<T>()
        {
            return new Logger_V1<T>( _configuration);
        }
    }
}

