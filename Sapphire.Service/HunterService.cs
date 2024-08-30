using AutoMapper;
using Sapphire.Contracts;
using Sapphire.Entities.Exceptions;
using Sapphire.Entities.Exceptions.BadRequest;
using Sapphire.Entities.Exceptions.NotFound;
using Sapphire.Entities.Models;
using Sapphire.Service.Contracts;
using Sapphire.Shared.DTO;
using Sapphire.Shared.Parameters;
using Sapphire.Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Service
{
    public sealed class HunterService : IHunterService
    {
        private readonly IRepositoryManager _repomanager;
        private readonly IMapper _mapper;
        private readonly IDataShaper<HunterDTO> _dataShaper;

        public HunterService(IRepositoryManager repomanager, IMapper mapper, IDataShaper<HunterDTO> dataShaper) { 
            _repomanager = repomanager;
            _mapper = mapper;
            _dataShaper = dataShaper;   
        }

        public async Task<(IEnumerable<Entity> Hunters, MetaData metadata)> GetAllHuntersAsync(bool track, HunterParameters HunterParams) {

                if (!HunterParams.ValidRankParameters)
                    throw new MaxHunterRankRequestException();
                var hn = await _repomanager.Hunter.GetAllHuntersAsync(track, HunterParams);
                var hnDto = _mapper.Map<IEnumerable<HunterDTO>>(hn);
                var shapedHunters = _dataShaper.ShapeData(hnDto, HunterParams.Field);
                return (Hunters: shapedHunters, metadata: hn.MetaData);          
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

        public async Task CheckDuplicateHunterAsync(string? HunterName,bool trackChanges)
        {
            if (string.IsNullOrWhiteSpace(HunterName))
                throw new HunterNameBlankException();

            var hunterExist = await _repomanager.Hunter.GetHunterByNameAsync(HunterName, trackChanges);
            if (hunterExist is null || HunterName.Equals(hunterExist.HunterName))
                return;
            else
                throw new HunterDuplicateException(HunterName);
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
                throw new HunterNotFoundException(HunterId.ToString());

            return hunter;
        }

        public async Task<(IEnumerable<HunterDTO> HunterLists, string HunterNames)> CreateMultipleHuntersAsync(IEnumerable<HunterCreationDTO> HunterListCreation)
        {
            if (HunterListCreation is null)
                throw new HunterListBadRequest();

            foreach (var huntername in HunterListCreation)
                await CheckDuplicateHunterAsync(huntername.HunterName, trackChanges: false);

            // convert list of hunters to Hunter Entity to be saved
            var mappedHunterList = _mapper.Map<IEnumerable<Hunters>>(HunterListCreation);
            foreach (var hunter in mappedHunterList)
                _repomanager.Hunter.CreateHunter(hunter);

            await _repomanager.SaveAsync();

            //convert back to DTO
            var mappedHunterListDto = _mapper.Map<IEnumerable<HunterDTO>>(mappedHunterList);
            var HunterName = string.Join(",", mappedHunterListDto.Select(x => x.HunterName));
            return (HunterLists:  mappedHunterListDto, HunterNames: HunterName);
        }

        public async Task<IEnumerable<HunterDTO>> GetMultipleHuntersByNameAsync(IEnumerable<string> HunterNames, bool TrackChanges)
        {
            var hunterlist = await _repomanager.Hunter.GetMultipleHuntersByNameAsync(HunterNames, TrackChanges);
            var mappedHunterList = _mapper.Map<IEnumerable<HunterDTO>>(hunterlist);
            return mappedHunterList;
        }

        public async Task DeleteHunterByIdAsync(Guid HunterId, bool Track)
        {
            var hunter = await _repomanager.Hunter.GetHunterAsync(HunterId, Track);
            var huntermapped = _mapper.Map<Hunters>(hunter);
            _repomanager.Hunter.DeleteHunter(huntermapped);
            await _repomanager.SaveAsync();
        }
        public async Task UpdateHunterByIdAsync(Guid hunterId, HunterUpdateDTO hud, bool trackChanges)
        {
            var hunter = await GetAndCheckIfHunterExistsById(hunterId, trackChanges);

            await CheckDuplicateHunterAsync(hud.HunterName, trackChanges);

            _mapper.Map(hud, hunter);
            await _repomanager.SaveAsync();
        }
    }
}
