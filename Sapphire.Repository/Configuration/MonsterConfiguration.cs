using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sapphire.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Repository.Configuration
{
    public class MonsterConfiguration : IEntityTypeConfiguration<Monsters>
    {
        public void Configure(EntityTypeBuilder<Monsters> builder)
        {
            builder.HasData(
                new Monsters
                {
                    Id = new Guid(Guid.NewGuid().ToString()),
                    MonsterName = "Rathian",
                    HealthPool = 10000.0,
                    BaseAttack = 1.0,
                    BaseDefense = 1.0,
                },
                new Monsters
                {
                    Id = new Guid(Guid.NewGuid().ToString()),
                    MonsterName = "Rathalos",
                    HealthPool = 10000.0,
                    BaseAttack = 1.0,
                    BaseDefense = 1.0,
                },
                new Monsters
                {
                    Id = new Guid(Guid.NewGuid().ToString()),
                    MonsterName = "Yian Garuga",
                    HealthPool = 5000.0,
                    BaseAttack = 1.0,
                    BaseDefense = 1.0,
                }
            );
        }
    }
}
