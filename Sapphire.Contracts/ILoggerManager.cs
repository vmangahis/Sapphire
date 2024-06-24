namespace Sapphire.Contracts
{
    public interface ILoggerManager
    {
         void LogDebug(string msg);
         void LogError(string msg);
          void LogWarning(string msg);
         void LogInformation(string msg);
    }
}
