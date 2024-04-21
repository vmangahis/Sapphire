using Sapphire.Contracts;
using Sapphire.Service.Contracts;

namespace Sapphire.Service
{
    public sealed class MonsterService : IMonsterService
    {
        private readonly IRepositoryManager _repomanager;
        private readonly ILoggerManager _logger;

        public MonsterService(IRepositoryManager repomanager, ILoggerManager logger) { 
            _repomanager = repomanager;
            _logger = logger;
        }
    }
}
