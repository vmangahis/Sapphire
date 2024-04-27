using AutoMapper;
using Sapphire.Entities.Models;
using Sapphire.Shared.DTO;
namespace Sapphire
{
    public class MapProfile : Profile
    {
            public MapProfile() {
            CreateMap<Monsters, MonsterDTO>()
                .ForMember(m => m.MonsterName, opt => opt.MapFrom(x => string.Join(" ", x.MonsterName, "TestConcat")));
        }
    }
}
