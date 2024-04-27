using Sapphire.Contracts;
using Sapphire.Service.Contracts;
using Sapphire.Entities.Models;
using Sapphire.Shared.DTO;

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

        public IEnumerable<MonsterDTO> GetAllMonsters(bool track)
        {
            try {
                var mons = _repomanager.Monster.GetAllMonsters(track);
                var monDto = mons.Select(monsters => {
                    return new MonsterDTO(monsters.Id, monsters.MonsterName);
                })
                .ToList();

                _logger.LogInformation("Logged Get All monsters");
                return monDto;
            } 
            
            catch(Exception ex) {
                _logger.LogError($"Error in Monster - {ex}");
                throw;
            }
        
        }

     
    }
}
