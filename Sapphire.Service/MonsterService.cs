using Sapphire.Contracts;
using Sapphire.Service.Contracts;
using Sapphire.Entities.Models;
using Sapphire.Shared.DTO;
using AutoMapper;

namespace Sapphire.Service
{
    internal sealed class MonsterService : IMonsterService
    {
        private readonly IRepositoryManager _repomanager;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public MonsterService(IRepositoryManager repomanager, ILoggerManager logger, IMapper map) { 
            _repomanager = repomanager;
            _logger = logger;
            _mapper = map;
        }

        public IEnumerable<MonsterDTO> GetAllMonsters(bool track)
        {
            try {
                var mons = _repomanager.Monster.GetAllMonsters(track);
                var monDto = _mapper.Map<IEnumerable<MonsterDTO>>(mons);

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
