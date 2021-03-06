﻿using Logger_V1.Logger.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Logger_V1.Logger
{
    internal class LoggerService : ILoggerService
    {
        private IConfigurationRoot _configuration;

        public LoggerService(IConfigurationRoot configuration)
        {
            _configuration = configuration;
        }

        public ILogger_V1<T> CreateLogger<T>()
        {
            return new Logger_V1<T>(_configuration);
        }
    }
}