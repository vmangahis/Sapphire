using AutoMapper;
using Sapphire.Entities.Models;
using Sapphire.Shared.DTO;
namespace Sapphire
{
    public class MapProfile : Profile
    {
            public MapProfile() {
            CreateMap<Monsters, MonsterDTO>()
                .ForCtorParam("TestName",
                opt => opt.MapFrom(x => string.Join(' ', x.MonsterName, "Wat")));

            CreateMap<Hunters, HunterDTO>();
        }
    }
}

//page 74
