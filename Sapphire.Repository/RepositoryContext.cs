using Microsoft.EntityFrameworkCore;
using Sapphire.Entities.Models;
using Sapphire.Repository.Configuration;
namespace Sapphire.Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions opt): base(opt) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HunterConfiguration());
            modelBuilder.ApplyConfiguration(new MonsterConfiguration());
            modelBuilder.ApplyConfiguration(new GuildConfiguration());
            modelBuilder.ApplyConfiguration(new LocaleConfiguration());
            modelBuilder.Entity<Hunters>()
                .HasOne(e => e.Guild)
                .WithMany(e => e.HunterMembers)
                .OnDelete(DeleteBehavior.SetNull);
                

        }

        public DbSet<Hunters>? T_hunters { get; set; }
        public DbSet<Monsters>? T_monsters { get; set; }
        public DbSet<Guild>? T_guild { get; set; }
        public DbSet<Locale>? T_locale { get; set; }

    }
}
