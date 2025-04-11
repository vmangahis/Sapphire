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
                Id = new Guid("60d5ae46-42f4-4b50-8be3-04a23d10a45f"),
                LocaleName = "Dummy Locale"
            });
        }

       
    }
}
