using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sapphire.Entities.Models;
using Sapphire.Service.Contracts;
using Sapphire.Shared.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Presentation.Controllers
{
    [Route("api/character")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly IServiceManager _serv;
        private readonly UserManager<SapphireUser> _userManager;
        public CharacterController(IServiceManager serv, UserManager<SapphireUser> usermanager)
        {
            _serv = serv;
            _userManager = usermanager;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> CreateCharacter(CharacterCreationDTO charDto)
        {
            var user = await _userManager.FindByNameAsync(User.Identity!.Name!);
            await _serv.CharacterService.CreateCharacter(charDto, user!);
            return Ok();
        }
        [HttpGet("{charid:guid}")]
        public async Task<ActionResult> GetCharacter(Guid charid)
        {
            var character = await _serv.CharacterService.GetCharacter(charid);
            return Ok(character);
        }
    }
}
