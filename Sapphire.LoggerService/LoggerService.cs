using NLog;
using Sapphire.Contracts;

namespace Sapphire.LoggerService
{
    public class LoggerService : ILoggerManager
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        public void LogDebug(string msg) => logger.Debug(msg);
        public void LogError(string msg) => logger.Error(msg);
        public void LogInformation(string msg) => logger.Info(msg);
        public void LogWarning(string msg) => logger.Warn(msg);
    }
}
