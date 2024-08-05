using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Shared.Base
{
    public abstract record MonsterForModificationDTO
    {
        [MaxLength(20)]
        [Required(ErrorMessage = "Please provide a monster name.")]
        public string MonsterName { get; set; } = "Dummy";
        [Required(ErrorMessage = "Health Pool missing")]
        public double HealthPool { get; set; } = 0.0;
        [Required(ErrorMessage = "Please provide a base attack stat.")]
        public double BaseAttack { get; set; } = 0.0;
        [Required(ErrorMessage = "Please provide a base defense stat.")]
        public double BaseDefense { get; set; } = 0.0;
    }
}
