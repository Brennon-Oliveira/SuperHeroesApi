using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using SuperHeroes.Domain;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperHeroes.Domain.Models;

namespace SuperHeroes.Infra.Data.Mappings
{
    internal class SuperPowersMap : IEntityTypeConfiguration<SuperPowers>
    {
        public void Configure(EntityTypeBuilder<SuperPowers> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasColumnType("varchar(50)").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Description).IsRequired().HasColumnType("varchar(250)").HasMaxLength(250);
            builder.HasIndex(x => x.Name).IsUnique();
        }
    }
}
