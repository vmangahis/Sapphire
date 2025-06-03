using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Sapphire.Entities.Models;
using Sapphire.Presentation.ActionFilters;
using Sapphire.Service.Contracts;
using Sapphire.Shared.DTO.Quest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Presentation.Controllers
{
    [Route("api/quest")]
    [ApiController]
    public class QuestController : ControllerBase
    {
        private readonly IServiceManager _service;
        private readonly UserManager<SapphireUser> _userManager;
        public QuestController(IServiceManager serv, UserManager<SapphireUser> usermanager) {
            _service = serv;
            _userManager = usermanager;
        }
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<ActionResult> PostQuest(PostQuestDTO postDto)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            // get user by current login
            var sapphireUser = await _userManager.FindByNameAsync(User.Identity!.Name!);
            bool validUser = await _service.CharacterService.VerifyCharacter(sapphireUser!, postDto.CharacterId!);
            if (!validUser) {
                return Forbid();
            }
            
            await _service.QuestService.PostQuest(postDto, sapphireUser!);
            return StatusCode(201);
        }
    }
}
