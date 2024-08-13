using AutoMapper;
using Sapphire.Contracts;
using Sapphire.Entities.Exceptions.BadRequest;
using Sapphire.Entities.Exceptions.NotFound;
using Sapphire.Entities.Models;
using Sapphire.Service.Contracts;
using Sapphire.Shared.DTO;
using Sapphire.Shared.Parameters;
using Sapphire.Shared.RequestFeatures;
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
        private readonly IMapper _mapper;
        public GuildService(IRepositoryManager repo, IMapper mapper) {
            _repomanager = repo;
            _mapper = mapper;
        }

        public async Task<(IEnumerable<GuildDTO> GuildList, MetaData metaData)> GetAllGuildAsync(bool track, GuildParameters guildParams)
        {
            var guild = await _repomanager.Guild.GetAllGuildAsync (track : false, guildParams);
            var guildList = _mapper.Map<IEnumerable<GuildDTO>>(guild);
            return (GuildList : guildList, metaData : guild.MetaData); 
        }

        public async Task<GuildDTO> GetSingleGuildAsync(Guid gid, bool track)
        {
            var guild = await CheckIfGuildExistsById(gid, track);
            var gl = _mapper.Map<GuildDTO>(guild);
            return gl;
        }

        public async Task<GuildMembersDTO> GetGuildMembersAsync(Guid gid, bool track) {
            var guild = await _repomanager.Guild.GetGuildMembersAsync(gid, track);
            var guildMembers = _mapper.Map<GuildMembersDTO>(guild);
            return guildMembers;
        }

        public async Task<GuildDTO> CreateGuildAsync(GuildCreationDTO gdto, bool track)
        {
            await CheckDuplicateGuildAsync(gdto.GuildName, track);
            
            var gd = _mapper.Map<Guild>(gdto);
            _repomanager.Guild.CreateGuild(gd);
            await _repomanager.SaveAsync();

            var gdResult = _mapper.Map<GuildDTO>(gd);
            return gdResult;
        }

        public async Task UpdateGuildAsync(string CurrentGuildName, GuildUpdateDTO gud, bool track)
        {
            var newGuildName = gud.GuildName;
            await CheckDuplicateGuildByName(newGuildName, track);

            var guild = await CheckIfGuildExistsByName(CurrentGuildName, track);

            _mapper.Map(gud, guild);
            await _repomanager.SaveAsync();
        }
        public async Task DeleteGuildAsync(string GuildName, bool track)
        {
            var guild = await CheckIfGuildExistsByName(GuildName, track);
   
            
            var mappedGuild = _mapper.Map<Guild>(guild);
            _repomanager.Guild.DeleteGuild(mappedGuild);
            await _repomanager.SaveAsync();
        }

        public async Task<(GuildUpdateDTO gdto, Guild guild)> PartialUpdateGuildAsync(string GuildName, bool track)
        {
            var guild = await CheckIfGuildExistsByName(GuildName, track);

            var mappedGuild = _mapper.Map<GuildUpdateDTO>(guild);
            return (mappedGuild, guild);
        }
        public async Task DeleteGuildByIdAsync(Guid GuildId, bool track)
        {
            var guild = await CheckIfGuildExistsById(GuildId, track);

            var mappedGuild = _mapper.Map<Guild>(guild);
            _repomanager.Guild.DeleteGuild(mappedGuild);
            await _repomanager.SaveAsync();
        }

        public async Task SaveGuildPatchAsync(GuildUpdateDTO gdto, Guild gd)
        {
            _mapper.Map(gdto, gd);
            await _repomanager.SaveAsync();
        }

        public async Task CheckDuplicateGuildAsync(string? NewGuildName, bool track)
        {
            if (string.IsNullOrWhiteSpace(NewGuildName)) 
                throw new GuildNameBlankException();
            
            var guild = await _repomanager.Guild.GetGuildByNameAsync(NewGuildName, track);
            if (guild is not null)
                throw new GuildDuplicateException(NewGuildName);

            return;
        }
        private async Task<Guild> CheckIfGuildExistsByName(string GuildName, bool TrackChanges) 
        {
            var guild = await _repomanager.Guild.GetGuildByNameAsync(GuildName, TrackChanges);
            if(guild is null)
                throw new GuildNotFound(GuildName);

            return guild;
        }
        private async Task<Guild> CheckIfGuildExistsById(Guid GuildId, bool TrackChanges)
        {
            var guild = await _repomanager.Guild.GetGuildAsync(GuildId, TrackChanges);
            if (guild is null)
                throw new GuildNotFound(GuildId.ToString());

            return guild;
        }
        private async Task CheckDuplicateGuildByName(string GuildName, bool TrackChanges)
        {
            var guild = await _repomanager.Guild.GetGuildByNameAsync(GuildName, TrackChanges);
            if (guild is not null)
                throw new GuildDuplicateException(GuildName);

            return;
        }
    }
}
