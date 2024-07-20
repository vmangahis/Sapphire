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

        public async Task<IEnumerable<GuildDTO>> GetAllGuildAsync(bool track)
        {
            var guild = await _repomanager.Guild.GetAllGuildAsync (track : false);
            var guildList = _mapper.Map<IEnumerable<GuildDTO>>(guild);
            return guildList; 
        }

        public async Task<GuildDTO> GetSingleGuildAsync(Guid gid, bool track)
        {
            var guild = await _repomanager.Guild.GetGuildAsync(gid, track);
            var gl = _mapper.Map<GuildDTO>(guild);
            return gl;
        }

        public async Task<GuildMembersDTO> GetGuildMembersAsync(Guid gid, bool track) {
            var guild = await _repomanager.Guild.GetGuildMembersAsync(gid, track);
            var guildMembers = _mapper.Map<GuildMembersDTO>(guild);
            return guildMembers;
        }

        public async Task<GuildDTO> CreateGuildAsync(GuildCreationDTO gdto)
        {
            var existGuild = await _repomanager.Guild.GetGuildByNameAsync(gdto.GuildName, false);
            if (existGuild is not null) 
                throw new GuildDuplicateException(gdto.GuildName);
            
            
            var gd = _mapper.Map<Guild>(gdto);
            _repomanager.Guild.CreateGuild(gd);
            await _repomanager.SaveAsync();

            var gdResult = _mapper.Map<GuildDTO>(gd);
            return gdResult;
        }

        public async Task UpdateGuildAsync(string CurrentGuildName, GuildUpdateDTO gud, bool track)
        {
            var newGuildName = gud.GuildName;
            var gd = await _repomanager.Guild.GetGuildByNameAsync(CurrentGuildName, track);
            if (gd is null) 
                throw new GuildNotFound(CurrentGuildName);
            

            _mapper.Map(gud, gd);
            await _repomanager.SaveAsync();
        }
        public async Task DeleteGuildAsync(string GuildName, bool track)
        {
            var guild = await _repomanager.Guild.GetGuildByNameAsync(GuildName, track);
            if (guild is null)
                throw new GuildNotFound(GuildName);
            
            var mappedGuild = _mapper.Map<Guild>(guild);
            _repomanager.Guild.DeleteGuild(mappedGuild);
            await _repomanager.SaveAsync();
        }

        public async Task<(GuildUpdateDTO gdto, Guild guild)> PartialUpdateGuildAsync(string GuildName, bool track)
        {
            var guild = await _repomanager.Guild.GetGuildByNameAsync(GuildName, track);
            if(guild is null)
                throw new GuildNotFound(GuildName);

            var mappedGuild = _mapper.Map<GuildUpdateDTO>(guild);
            return (mappedGuild, guild);
        }

        public async Task SaveGuildPatchAsync(GuildUpdateDTO gdto, Guild gd)
        {
            _mapper.Map(gdto, gd);
            await _repomanager.SaveAsync();
        }

        public async Task CheckDuplicateGuildAsync(string NewGuildName, bool track)
        {
            if (string.IsNullOrWhiteSpace(NewGuildName)) 
                throw new GuildNameBlankException();
            
            var guild = await _repomanager.Guild.GetGuildByNameAsync(NewGuildName, track);
            if (guild is not null)
                throw new GuildDuplicateException(NewGuildName);

            return;
        }
    }
}
