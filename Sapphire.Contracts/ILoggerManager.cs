namespace Sapphire.Contracts
{
    public interface ILoggerManager
    {
        public void LogDebug(string msg);
        public void LogError(string msg);
        public  void LogWarning(string msg);
        public void LogInformation(string msg);
    }
}
