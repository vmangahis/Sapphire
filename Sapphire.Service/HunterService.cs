using AutoMapper;
using Sapphire.Contracts;
using Sapphire.Entities.Exceptions;
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
    public sealed class HunterService : IHunterService
    {
        private readonly IRepositoryManager _repomanager;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public HunterService(IRepositoryManager repomanager, ILoggerManager logger, IMapper mapper) { 
            _repomanager = repomanager;
            _logger = logger;  
            _mapper = mapper;


        }

        public IEnumerable<HunterDTO> GetAllHunters(bool track) {
            
                var hn = _repomanager.Hunter.GetAllHunters(track);
                var hnDto = _mapper.Map<IEnumerable<HunterDTO>>(hn);
                _logger.LogInformation("Got all hunters");
                return hnDto;          
        }

        public HunterDTO GetHunter(Guid huntId, bool track)
        {
            var hn = _repomanager.Hunter.GetHunter(huntId, track);
            if (hn is null) {
                throw new HunterNotFoundException(huntId);
            }
            var hnDto = _mapper.Map<HunterDTO>(hn);
            return hnDto;
        }

        public HunterDTO CreateHunter(HunterCreationDTO hunter)
        {
            var hn = _mapper.Map<Hunters>(hunter);
            _repomanager.Hunter.CreateHunter(hn);
            _repomanager.Save();

            var retValue = _mapper.Map<HunterDTO>(hn);
            return retValue;
        }

    }
}
