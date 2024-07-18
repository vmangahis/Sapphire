using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sapphire.Entities.Models;
using Sapphire.Shared.DTO;


namespace Sapphire.Service.Contracts
{
    public interface IGuildService
    {
        IEnumerable<GuildDTO> GetAllGuild(bool track);
        GuildDTO GetSingleGuild(Guid gid, bool track);
        GuildMembersDTO GetGuildMembers(Guid gid, bool track);
        GuildDTO CreateGuild(GuildCreationDTO gdto);
        (GuildUpdateDTO gdto, Guild guild) PartialUpdateGuild(string GuildName, bool track);
        void SaveGuildPatch(GuildUpdateDTO gdto, Guild gd);
        void UpdateGuild(string CurrentGuildName, GuildUpdateDTO gud, bool track);
        void DeleteGuild(string GuildName, bool track);
        void CheckDuplicateGuild(string NewGuildName, bool track);
    }
}
