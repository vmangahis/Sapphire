using Sapphire.Contracts;
using Sapphire.Service.Contracts;
using Sapphire.Entities.Models;
using Sapphire.Shared.DTO;
using AutoMapper;
using Sapphire.Entities.Exceptions;
using Sapphire.Entities.Exceptions.NotFound;

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
            
                var mons = _repomanager.Monster.GetAllMonsters(track);
                var monDto = _mapper.Map<IEnumerable<MonsterDTO>>(mons);

                _logger.LogInformation("Logged Get All monsters");
                return monDto;          
        }

        public MonsterDTO GetMonster(Guid monId, bool track)
        {
            var mon = _repomanager.Monster.GetMonster(monId, track);
            if (mon == null)
                throw new MonsterNotFoundException(monId);
            var monDto = _mapper.Map<MonsterDTO>(mon);
            return monDto;
        }
    }
}
