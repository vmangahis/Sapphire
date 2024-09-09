using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Sapphire.Contracts;
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
    public sealed class SapphireUserService : ISapphireUserService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;
        private readonly UserManager<SapphireUser> _userManager;
        private SapphireUser? _saphUser;
        public SapphireUserService(IRepositoryManager repoManager, IMapper map, UserManager<SapphireUser> userManager) { 
            _mapper = map;
            _repositoryManager = repoManager;
            _userManager = userManager;
        }

        public async Task PurgeUserAsync(SapphireUserForPurgeDTO saphPurgeDto)
        {
            _saphUser = await _userManager.FindByIdAsync(saphPurgeDto.SapphireUserId.ToString());
            if (_saphUser == null)
                throw new SapphireUserNotFound();

            await _userManager.DeleteAsync(_saphUser);
        }
    }
}
