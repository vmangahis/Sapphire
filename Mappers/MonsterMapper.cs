using Sapphire.DTO.Monster;
using Sapphire.Models;
using System.Runtime.CompilerServices;

namespace Sapphire.Mappers
{
    public static class MonsterMapper
    {
        public static Monsters ToMonsterAddMonsterDTO(this AddMonsterDTO addmondto) {
            return new Monsters
            {
                MonsterName =  addmondto.MonsterName,
            };
        }
    }
}
