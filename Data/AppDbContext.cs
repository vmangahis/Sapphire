using Microsoft.EntityFrameworkCore;
using Sapphire.Models;

namespace Sapphire.Data
{
    public class AppDbContext : DbContext
    {
        
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt) { }

        public DbSet<Monsters> T_monsters { get; set; }
        public DbSet<Hunters> T_hunters { get; set; }

 
    }
}
