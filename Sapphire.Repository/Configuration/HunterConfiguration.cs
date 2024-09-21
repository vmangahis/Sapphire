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
           
        }
    }
}
