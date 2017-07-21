namespace Logger_V1.Logger.Interfaces
{
    public interface ILoggerService
    {
        ILogger_V1<T> CreateLogger<T>();
    }
}