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
    public class CharacterRoleConfiguration : IEntityTypeConfiguration<CharacterRole>
    {
        public void Configure(EntityTypeBuilder<CharacterRole> builder)
        {
            builder.HasData(
             new CharacterRole
             {
                 RoleId = new Guid(Guid.NewGuid().ToString()),
                 RoleName = "Hunter",
                 CreatedDateTime = DateTime.Now,
                 UpdatedDateTime = DateTime.Now,
             },
             new CharacterRole
             {
                 RoleId = new Guid(Guid.NewGuid().ToString()),
                 RoleName = "Client",
                 CreatedDateTime = DateTime.Now,
                 UpdatedDateTime = DateTime.Now,
             }

             );
        }
    }
}
