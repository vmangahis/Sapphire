using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Entities.Models
{
    public class Monsters
    {
        public Guid Id { get; set; }
        public string MonsterName { get; set; } = "Dummy";
        public double HealthPool { get; set; } = 0.0;
        public double BaseAttack { get; set; } = 0.0; 
        public double BaseDefense { get; set; } = 0.0;
    }
}
