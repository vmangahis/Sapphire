using Sapphire.Contracts;
using Sapphire.Service.Contracts;
using Sapphire.Entities.Models;

namespace Sapphire.Service
{
    internal sealed class MonsterService : IMonsterService
    {
        private readonly IRepositoryManager _repomanager;
        private readonly ILoggerManager _logger;

        public MonsterService(IRepositoryManager repomanager, ILoggerManager logger) { 
            _repomanager = repomanager;
            _logger = logger;
        }

        public IEnumerable<Monsters> GetAllMonsters(bool track)
        {
            try {
                var mons = _repomanager.Monster.GetAllMonsters(track);
                _logger.LogInformation("Logged Get All monsters");
                return mons;
            } 
            
            catch(Exception ex) {
                _logger.LogError($"Error in Monster - {ex}");
                throw;
            }
        
        }

     
    }
}
