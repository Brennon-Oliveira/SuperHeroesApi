using Microsoft.EntityFrameworkCore;
using SuperHeroes.Domain.Models;
using SuperHeroes.Infra.Data.Mappings;
using System;

namespace SuperHeroes.Infra.Data.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Domain.Models.SuperHeroes> SuperHeroes { get; set; }
        public DbSet<SuperPowers> SuperPowers { get; set; }
        public DbSet<SuperHeroesSuperPowers> SuperHeroesSuperPowers { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfiguration(new SuperHeroesMap());
            modelBuilder.ApplyConfiguration(new SuperPowersMap());
            modelBuilder.ApplyConfiguration(new SuperHeroesSuperPowersMap());

            modelBuilder.Entity<SuperHeroesSuperPowers>().HasNoKey();

            base.OnModelCreating(modelBuilder);
        }
    }
}