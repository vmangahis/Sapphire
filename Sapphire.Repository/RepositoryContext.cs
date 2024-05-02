﻿using Microsoft.EntityFrameworkCore;
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
        }

        public DbSet<Hunters>? T_hunters { get; set; }
        public DbSet<Monsters>? T_monsters { get; set; }

    }
}