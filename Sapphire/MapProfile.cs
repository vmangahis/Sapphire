﻿using AutoMapper;
using Sapphire.Entities.Models;
using Sapphire.Shared.Base;
using Sapphire.Shared.DTO.Guild;
using Sapphire.Shared.DTO.Hunter;
using Sapphire.Shared.DTO.Monster;
using Sapphire.Shared.DTO.SapphireUser;
namespace Sapphire
{
    public class MapProfile : Profile
    {
            public MapProfile() {
            CreateMap<Monsters, MonsterDTO>();
            CreateMap<MonsterCreationDTO, Monsters>();
            CreateMap<Monsters, MonsterForModificationDTO>();
            CreateMap<Hunters, HunterDTO>();
            CreateMap<Hunters, HunterMemberDTO>();
            CreateMap<Guild, GuildDTO>();
            CreateMap<Guild, GuildMembersDTO>();
            CreateMap<Guild, GuildForHunterMemberDTO>();
            CreateMap<GuildForHunterMemberDTO, Guild>();
            CreateMap<GuildMembersDTO, GuildDTO>();
            CreateMap<HunterCreationDTO, Hunters>();
            CreateMap<GuildCreationDTO, Guild>();
            CreateMap<GuildUpdateDTO, Guild>().ReverseMap();
            CreateMap<HunterUpdateDTO, Hunters>().ReverseMap();
            CreateMap<SapphireUserForRegistrationDTO, SapphireUser>();
            CreateMap<CharacterCreationDTO, Character>().ReverseMap();
        }
    }
}