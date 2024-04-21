using Sapphire.Contracts;
using Sapphire.Service.Contracts;
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

        public HunterService(IRepositoryManager repomanager, ILoggerManager logger) { 
            _repomanager = repomanager;
            _logger = logger;        
        }
    }
}
