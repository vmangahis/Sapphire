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
        [Column("MonsterId")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [MaxLength(40, ErrorMessage = "Max length is 40 characters")]
        public string MonsterName { get; set; } = "Dummy";
        public double HealthPool { get; set; } = 0.0;
        public double BaseAttack { get; set; } = 0.0;
        public double BaseDefense { get; set; } = 0.0;
    }
}
