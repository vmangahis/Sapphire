using AutoMapper;
using Sapphire.Contracts;
using Sapphire.Service.Contracts;
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
        public SapphireUserService(IRepositoryManager repoManager, IMapper map) { 
            _mapper = map;
            _repositoryManager = repoManager;
        }
    }
}
