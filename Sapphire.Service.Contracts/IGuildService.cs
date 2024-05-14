using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sapphire.Shared.DTO;


namespace Sapphire.Service.Contracts
{
    public interface IGuildService
    {
        IEnumerable<GuildDTO> GetAllGuild(bool track);
        GuildDTO GetSingleGuild(Guid gid, bool track);;
    }
}
