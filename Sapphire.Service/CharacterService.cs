using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Sapphire.Contracts;
using Sapphire.Entities.Exceptions;
using Sapphire.Entities.Exceptions.BadRequest;
using Sapphire.Entities.Models;
using Sapphire.Service.Contracts;
using Sapphire.Shared.Base;
using Sapphire.Shared.DTO.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Service
{
    public class CharacterService : ICharacterService
    {
        private readonly IRepositoryManager _repoManager;
        private readonly IMapper _mapper;
        private readonly UserManager<SapphireUser> _saphUser;
        public CharacterService(IRepositoryManager repomanager, IMapper mapper, UserManager<SapphireUser> saphUser)
        {
            _repoManager = repomanager;
            _mapper = mapper;
            _saphUser = saphUser;
        }
        public async Task<CharacterDTO> GetCharacter(Guid characterId)
        {
            var character = await _repoManager.Character.GetCharacter(characterId);
            var charDto = _mapper.Map<CharacterDTO>(character);
            return charDto;
        }

        public async Task CreateCharacter(CharacterCreationDTO charDto, SapphireUser saphUser)
        {
            
            var characterFull = await CheckCharacterLimit(saphUser);

            var charRole = await _repoManager.Role.GetRole(charDto.RoleId);

            if (charRole is null)
                throw new CharacterRoleNotFound("Role does not exists.");

            if (characterFull)
                throw new MaxCharacterCreation();

            var character = _mapper.Map<Character>(charDto);
            character.User = saphUser;
            character.RoleId = charDto.RoleId;

            if(charRole.RoleName?.ToUpper() == "HUNTER")
            {
                Hunters hunterObject = new Hunters
                {
                    HunterName = charDto.CharacterName,
                    SapphireUser = saphUser
                };
                  _repoManager.Hunter.CreateHunter(hunterObject);
            }
            
            _repoManager.Character.CreateCharacter(character);
            await _repoManager.SaveAsync();
        }

        private async Task<bool> CheckCharacterLimit(SapphireUser saphUser)
        {
            var owners = await _repoManager.Character.GetCharacterOwnerById(new Guid(saphUser.Id));
            if(owners.Count() == 2)
              return true;
            
            return false;
        }

    }
}
