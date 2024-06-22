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
            CreateMap<Guild, GuildMembersDTO>();
            CreateMap<GuildMembersDTO, GuildDTO>();
            CreateMap<HunterCreationDTO, Hunters>();
            CreateMap<GuildCreationDTO, Guild>();
        }
    }
}