using Sapphire.Contracts;
using Sapphire.Entities.Models;
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

        public IEnumerable<Hunters> GetAllHunters(bool track) {
            try
            {
                var hn = _repomanager.Hunter.GetAllHunters(track);
                _logger.LogInformation("Got all hunters");
                return hn;
            }
            catch(Exception e) {
                _logger.LogError("Something wrong with method Get All Hunters");
                Console.WriteLine("Error something");
                throw;
            }

        }
    }
}
