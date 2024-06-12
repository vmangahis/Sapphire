using AutoMapper;
using Sapphire.Entities.Models;
using Sapphire.Shared.DTO;
namespace Sapphire
{
    public class MapProfile : Profile
    {
            public MapProfile() {
            CreateMap<Monsters, MonsterDTO>();
            CreateMap<Hunters, HunterDTO>();
            CreateMap<Guild, GuildDTO>();
            CreateMap<HunterCreationDTO, Hunters>();
        }
    }
}

//page 74
