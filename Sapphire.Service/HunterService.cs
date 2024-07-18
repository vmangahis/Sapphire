using AutoMapper;
using Sapphire.Contracts;
using Sapphire.Entities.Exceptions;
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
            if (hn is null) 
                throw new HunterNotFoundException(huntId.ToString());
            
            var hnDto = _mapper.Map<HunterDTO>(hn);
            return hnDto;
        }

        public HunterDTO CreateHunter(HunterCreationDTO hunter)
        {
            var existHunter = _repomanager.Hunter.GetHunterByName(hunter.HunterName, false);
            if (existHunter != null) 
                throw new HunterDuplicateException(hunter.HunterName);
            
            var hn = _mapper.Map<Hunters>(hunter);
            _repomanager.Hunter.CreateHunter(hn);
            _repomanager.Save();

            var retValue = _mapper.Map<HunterDTO>(hn);
            return retValue;
        }
        public HunterDTO GetHunterByName(string HunterName, bool track) {
            var hunter = _repomanager.Hunter.GetHunterByName(HunterName, false);
            if (hunter == null) 
                throw new HunterNotFoundException(HunterName);
            
            var mapHunter = _mapper.Map<HunterDTO>(hunter);
            return mapHunter;
            
        }
        public void DeleteHunter(string HunterName) {
            var hunter = _repomanager.Hunter.GetHunterByName(HunterName, false);
            if (hunter == null)
                throw new HunterNotFoundException(HunterName);
            
            var mappedHunter = _mapper.Map<Hunters>(hunter);
            _repomanager.Hunter.DeleteHunter(mappedHunter);
            _repomanager.Save(); 
        }
        public void UpdateHunter(string CurrentHunterName,HunterUpdateDTO hud, bool TrackChanges) {
            var hunter = _repomanager.Hunter.GetHunterByName(CurrentHunterName, TrackChanges);
            if (hunter is null) 
                throw new HunterNotFoundException(CurrentHunterName);
            
            _mapper.Map(hud, hunter);
            _repomanager.Save();

        }

        public (HunterUpdateDTO hud, Hunters hunt) GetHunterPatch(string CurrentHunterName, bool TrackChanges)
        {
            var hunter = _repomanager.Hunter.GetHunterByName(CurrentHunterName, TrackChanges);
            
            if (hunter == null)
                throw new HunterNotFoundException(CurrentHunterName);

            var hunterPatch = _mapper.Map<HunterUpdateDTO>(hunter);
            return (hunterPatch, hunter);
        }

        public void SaveHunterChangesPatch(HunterUpdateDTO hud, Hunters hunt)
        {
            _mapper.Map(hud, hunt);
            _repomanager.Save();
        }

        public void CheckDuplicateHunter(string HunterName,bool Track)
        {
            if (string.IsNullOrWhiteSpace(HunterName))
                throw new HunterNameBlankException();

            var hunterExist = _repomanager.Hunter.GetHunterByName(HunterName, Track);
            if (hunterExist is not null)
                throw new HunterDuplicateException(HunterName);

            return;
        }
    }
}
