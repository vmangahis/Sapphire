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
                    Id = new Guid("833a6dfe-c7f3-40d5-8773-c66a4bd9cf52"),
                    MonsterName = "Rathian",
                    HealthPool = 10000.0,
                    BaseAttack = 1.0,
                    BaseDefense = 1.0,
                },
                new Monsters
                {
                    Id = new Guid("0cf7a88d-1101-49cb-b96c-8cd631841fda"),
                    MonsterName = "Rathalos",
                    HealthPool = 10000.0,
                    BaseAttack = 1.0,
                    BaseDefense = 1.0,
                },
                new Monsters
                {
                    Id = new Guid("6d4894af-9d8d-4ea1-a68b-a883b51f1e3c"),
                    MonsterName = "Yian Garuga",
                    HealthPool = 5000.0,
                    BaseAttack = 1.0,
                    BaseDefense = 1.0,
                }
            );
        }
    }
}
