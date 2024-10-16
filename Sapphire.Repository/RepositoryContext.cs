using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sapphire.Entities.Models;
using Sapphire.Repository.Configuration;
namespace Sapphire.Repository
{
    public class RepositoryContext : IdentityDbContext<SapphireUser>
    {
        public RepositoryContext(DbContextOptions opt): base(opt) {  }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new HunterConfiguration());
            modelBuilder.ApplyConfiguration(new MonsterConfiguration());
            modelBuilder.ApplyConfiguration(new GuildConfiguration());
            modelBuilder.ApplyConfiguration(new LocaleConfiguration());
            modelBuilder.Entity<Hunters>()
                .HasOne(e => e.Guild)
                .WithMany(e => e.HunterMembers)
                .OnDelete(DeleteBehavior.SetNull);


            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new CharacterRoleConfiguration());
            modelBuilder.Entity<HunterClient>()
                .HasKey(e => e.ClientId);
                
                
        }

        public DbSet<Hunters>? T_hunters { get; set; }
        public DbSet<Monsters>? T_monsters { get; set; }
        public DbSet<Guild>? T_guild { get; set; }
        public DbSet<Locale>? T_locale { get; set; }
        public DbSet<Quest>? T_quest { get; set; }
        public DbSet<Character>? T_characters { get; set; }
        public DbSet<CharacterRole>? T_characterRoles { get; set; }
        public DbSet<HunterClient>? T_hunterClients { get; set; }

    }
}
