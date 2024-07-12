using AutoMapper;
using Sapphire.Contracts;
using Sapphire.Entities.Exceptions.BadRequest;
using Sapphire.Entities.Exceptions.NotFound;
using Sapphire.Entities.Models;
using Sapphire.Service.Contracts;
using Sapphire.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Service
{
    public sealed class GuildService : IGuildService
    {
        private readonly IRepositoryManager _repomanager;
        private readonly ILoggerManager _loggerManager;
        private readonly IMapper _mapper;
        public GuildService(IRepositoryManager repo, ILoggerManager logger, IMapper mapper) {
            _repomanager = repo;
            _loggerManager = logger;
            _mapper = mapper;
        }

        public IEnumerable<GuildDTO> GetAllGuild(bool track)
        {
            var guild = _repomanager.Guild.GetAllGuild(track : false);
            var guildList = _mapper.Map<IEnumerable<GuildDTO>>(guild);
            return guildList; 
        }

        public GuildDTO GetSingleGuild(Guid gid, bool track)
        {
            var guild = _repomanager.Guild.GetGuild(gid, track);
            var gl = _mapper.Map<GuildDTO>(guild);
            return gl;
        }

        public GuildMembersDTO GetGuildMembers(Guid gid, bool track) {
            var guild = _repomanager.Guild.GetGuildMembers(gid, track);
            var guildMembers = _mapper.Map<GuildMembersDTO>(guild);
            return guildMembers;
        }

        public GuildDTO CreateGuild(GuildCreationDTO gdto)
        {
            var existGuild = _repomanager.Guild.GetGuildByName(gdto.GuildName, false);
            if (existGuild is not null) {
                throw new GuildDuplicateException(gdto.GuildName);
            }
            
            var gd = _mapper.Map<Guild>(gdto);
            _repomanager.Guild.CreateGuild(gd);
            _repomanager.Save();

            var gdResult = _mapper.Map<GuildDTO>(gd);
            return gdResult;
        }

        public void UpdateGuild(string CurrentGuildName, GuildUpdateDTO gud, bool track)
        {
            var newGuildName = gud.GuildName;
            var gd = _repomanager.Guild.GetGuildByName(CurrentGuildName, track);
            var guildExist = _repomanager.Guild.GetGuildByName(newGuildName, false);
            if (gd is null) {
                throw new GuildNotFound(CurrentGuildName);
            }
            if (guildExist is not null) {
                throw new GuildDuplicateException(newGuildName);
            }
            _mapper.Map(gud, gd);
            _repomanager.Save();
        }
        public void DeleteGuild(string GuildName, bool track)
        {
            var guild = _repomanager.Guild.GetGuildByName(GuildName, track);
            if (guild is null)
                throw new GuildNotFound(GuildName);
            
            var mappedGuild = _mapper.Map<Guild>(guild);
            _repomanager.Guild.DeleteGuild(mappedGuild);
            _repomanager.Save();
        }
        
    }
}
