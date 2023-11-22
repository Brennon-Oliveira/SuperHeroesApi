using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using SuperHeroes.Domain;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SuperHeroes.Infra.Data.Mappings
{
    internal class SuperHeroesMap : IEntityTypeConfiguration<Domain.Models.SuperHeroes>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.SuperHeroes> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasColumnType("varchar(120)").HasMaxLength(120);
            builder.Property(x => x.HeroName).IsRequired().HasColumnType("varchar(120)").HasMaxLength(120);

            builder.HasIndex(x => x.Name).IsUnique();
            builder.HasIndex(x => x.HeroName).IsUnique();  
        }
    }
}
