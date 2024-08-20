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
    public class HunterConfiguration : IEntityTypeConfiguration<Hunters>
    {
        public void Configure(EntityTypeBuilder<Hunters> builder)
        {
            builder.HasData(
                new Hunters { 
                Id = new Guid(Guid.NewGuid().ToString()),
                HunterName = "Shard",
                Rank = 1,
                ZennyAmount = 5000.0
                },
                new Hunters
                {
                    Id = new Guid(Guid.NewGuid().ToString()),
                    HunterName = "DarkShard",
                    Rank = 1,
                    ZennyAmount = 5000.0
                    
                },
                new Hunters { 
                
                    Id =  new Guid(Guid.NewGuid().ToString()),
                    HunterName = "Astera",
                    Rank = 50,
                    ZennyAmount = 9000.0

                }


            );
        }
    }
}
