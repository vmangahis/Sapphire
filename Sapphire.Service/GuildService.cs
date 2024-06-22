using AutoMapper;
using Sapphire.Contracts;
using Sapphire.Entities.Exceptions.BadRequest;
using Sapphire.Entities.Exceptions.NotFound;
using Sapphire.Entities.Models;
using Sapphire.Service.Contracts;
using Sapphire.Shared.DTO;
using System;
using System.Collections.Generic;
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
            if (gdto.HunterMembers is not null) { 
                  var hunter_members = gdto.HunterMembers.ToList();
                hunter_members.ForEach(e =>
                {
                    
                    var hunter = _repomanager.Hunter.GetHunterByName(e.HunterName, false);
                    if (hunter is null) {
                        throw new HunterNotFoundException(e.HunterName);
                    }
                   
                    if (hunter.GuildId is not null || hunter.GuildId != Guid.Empty) {
                        throw new HunterAlreadyJoinedGuildException(e.HunterName);
                    }

                });
            
            }
            var gd = _mapper.Map<Guild>(gdto);
            _repomanager.Guild.CreateGuild(gd);
            _repomanager.Save();

            var gdResult = _mapper.Map<GuildDTO>(gd);
            return gdResult;
        }
    }
}
