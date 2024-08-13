using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sapphire.Entities.Models;
using Sapphire.Shared.DTO;
using Sapphire.Shared.Parameters;
using Sapphire.Shared.RequestFeatures;


namespace Sapphire.Service.Contracts
{
    public interface IGuildService
    {
        Task<(IEnumerable<GuildDTO> GuildList, MetaData metaData)> GetAllGuildAsync(bool track, GuildParameters guildParams);
        Task<GuildDTO> GetSingleGuildAsync(Guid gid, bool track);
        Task<GuildMembersDTO> GetGuildMembersAsync(Guid gid, bool track);
        Task<GuildDTO> CreateGuildAsync(GuildCreationDTO gdto, bool track);
        Task<(GuildUpdateDTO gdto, Guild guild)> PartialUpdateGuildAsync(string GuildName, bool track);
        Task SaveGuildPatchAsync(GuildUpdateDTO gdto, Guild gd);
        Task UpdateGuildAsync(string CurrentGuildName, GuildUpdateDTO gud, bool track);
        Task DeleteGuildAsync(string GuildName, bool track);
        Task CheckDuplicateGuildAsync(string NewGuildName, bool track);
        Task DeleteGuildByIdAsync(Guid GuildId, bool track);
    }
}
