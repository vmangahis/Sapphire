using Sapphire.Contracts;
using Sapphire.Service.Contracts;
using Sapphire.Entities.Models;
using AutoMapper;
using Sapphire.Entities.Exceptions;
using Sapphire.Entities.Exceptions.NotFound;
using Sapphire.Shared.DTO.Monster;

namespace Sapphire.Service
{
    public sealed class MonsterService : IMonsterService
    {
        private readonly IRepositoryManager _repomanager;
        private readonly IMapper _mapper;

        public MonsterService(IRepositoryManager repomanager, IMapper map) { 
            _repomanager = repomanager;
            _mapper = map;
        }

        public IEnumerable<MonsterDTO> GetAllMonsters(bool track)
        {
            
                var mons = _repomanager.Monster.GetAllMonsters(track);
                var monDto = _mapper.Map<IEnumerable<MonsterDTO>>(mons);
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
        public async Task<MonsterDTO> CreateMonster(MonsterCreationDTO monsterCreationDTO)
        {
            var moncreateDto = monsterCreationDTO;
            var mappedMonster = _mapper.Map<Monsters>(monsterCreationDTO);
             _repomanager.Monster.CreateMonster(mappedMonster);
            await _repomanager.SaveAsync();
            var monsterDto = _mapper.Map<MonsterDTO>(mappedMonster);
            return monsterDto;
        }
    }
}
