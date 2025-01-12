using Microsoft.EntityFrameworkCore;
using Sapphire.Contracts;
using Sapphire.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Repository
{
    public class RoleRepository : RepositoryBase<CharacterRole>, IRoleRepository
    {
        public RoleRepository(RepositoryContext repoCont) : base(repoCont) { }

        public async Task<CharacterRole> GetRole(Guid roleId) {
            var charRole =  await GetThroughCondition(e => e.RoleId == roleId, false).FirstOrDefaultAsync();
            return charRole ?? new CharacterRole { };
         }
    }
}
