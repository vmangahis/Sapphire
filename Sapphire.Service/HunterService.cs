﻿using AutoMapper;
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

        public async Task<IEnumerable<HunterDTO>> GetAllHuntersAsync(bool track) {
            
                var hn = await _repomanager.Hunter.GetAllHuntersAsync(track);
                var hnDto = _mapper.Map<IEnumerable<HunterDTO>>(hn);
                _logger.LogInformation("Got all hunters");
                return hnDto;          
        }

        public async Task<HunterDTO> GetHunterAsync(Guid huntId, bool track)
        {
            var hn = await GetAndCheckIfHunterExistsById(huntId, track);
            
            var hnDto = _mapper.Map<HunterDTO>(hn);
            return hnDto;
        }

        public async Task<HunterDTO> CreateHunterAsync(HunterCreationDTO hunter)
        {
            var existHunter = await _repomanager.Hunter.GetHunterByNameAsync(hunter.HunterName, false);
            if (existHunter != null) 
                throw new HunterDuplicateException(hunter.HunterName);
            
            var hn = _mapper.Map<Hunters>(hunter);
            _repomanager.Hunter.CreateHunter(hn);
            await _repomanager.SaveAsync();

            var retValue = _mapper.Map<HunterDTO>(hn);
            return retValue;
        }
        public async Task<HunterDTO> GetHunterByNameAsync(string HunterName, bool track) {
            var hunter = await GetAndCheckIfHunterExistsByName(HunterName, track);
            
            var mapHunter = _mapper.Map<HunterDTO>(hunter);
            return mapHunter;
            
        }
        public async Task DeleteHunterAsync(string HunterName, bool Track) {
            var hunter = await GetAndCheckIfHunterExistsByName(HunterName, Track);

            var mappedHunter = _mapper.Map<Hunters>(hunter);
            _repomanager.Hunter.DeleteHunter(mappedHunter);
            await _repomanager.SaveAsync(); 
        }
        public async Task UpdateHunterAsync(string CurrentHunterName,HunterUpdateDTO hud, bool TrackChanges) {
            var hunter = await GetAndCheckIfHunterExistsByName(CurrentHunterName, TrackChanges);

            await CheckDuplicateHunterAsync(hud.HunterName, TrackChanges);

            _mapper.Map(hud, hunter);
            await _repomanager.SaveAsync();

        }

        public async Task<(HunterUpdateDTO hud, Hunters hunt)> GetHunterPatchAsync(string CurrentHunterName, bool TrackChanges)
        {
            var hunter = await GetAndCheckIfHunterExistsByName(CurrentHunterName, TrackChanges);

            var hunterPatch = _mapper.Map<HunterUpdateDTO>(hunter);
            return (hunterPatch, hunter);
        }

        public async Task SaveHunterChangesPatchAsync(HunterUpdateDTO hud, Hunters hunt)
        {
            _mapper.Map(hud, hunt);
            await _repomanager.SaveAsync();
        }

        public async Task CheckDuplicateHunterAsync(string? HunterName,bool Track)
        {
            if (string.IsNullOrWhiteSpace(HunterName))
                throw new HunterNameBlankException();

            var hunterExist = await _repomanager.Hunter.GetHunterByNameAsync(HunterName, Track);
            if (hunterExist is not null)
                throw new HunterDuplicateException(HunterName);

            return;
        }
        private async Task<Hunters> GetAndCheckIfHunterExistsByName(string HunterName, bool Track) {
            var hunter = await _repomanager.Hunter.GetHunterByNameAsync(HunterName, Track);
            if (hunter is null)
                throw new HunterNotFoundException(HunterName);

            return hunter;
        }
        private async Task<Hunters> GetAndCheckIfHunterExistsById(Guid HunterId, bool Track)
        {
            var hunter = await _repomanager.Hunter.GetHunterAsync(HunterId, Track);
            if (hunter is null)
                throw new HunterNotFoundException(hunter.HunterName);

            return hunter;
        }
    }
}
