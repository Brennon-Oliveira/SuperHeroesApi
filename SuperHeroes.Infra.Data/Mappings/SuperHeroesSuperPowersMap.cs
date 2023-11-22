using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperHeroes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroes.Infra.Data.Mappings
{
    internal class SuperHeroesSuperPowersMap : IEntityTypeConfiguration<SuperHeroesSuperPowers>
    {
        public void Configure(EntityTypeBuilder<SuperHeroesSuperPowers> builder)
        {

            builder
                .HasOne(x => x.SuperHeroe)
                .WithMany(x => x.SuperPowers)
                .HasForeignKey(x => x.SuperHeroesId)
                .IsRequired();

            builder
                .HasOne(x => x.SuperPowers)
                .WithMany(x => x.SuperHeroes)
                .HasForeignKey(x => x.SuperPowersId)
                .IsRequired();
        }
    }
}
