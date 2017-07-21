using System;

namespace Logger_V1.Logger.Interfaces
{
    public interface ILogger_V1<T>
    {
        void Log(string msg, LogType logType = LogType.Information);
        void LogException(string from, Exception ex);
    }
}

