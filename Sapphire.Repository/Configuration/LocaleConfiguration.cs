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
    public class LocaleConfiguration : IEntityTypeConfiguration<Locale>
    {
        public void Configure(EntityTypeBuilder<Locale> builder) {
            builder.HasData(new Locale { 
                Id = new Guid(Guid.NewGuid().ToString()),
                LocaleName = "Dummy Locale"
            });
        }

       
    }
}
