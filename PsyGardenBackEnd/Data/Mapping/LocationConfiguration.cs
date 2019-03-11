using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PsyGardenBackEnd.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsyGardenBackEnd.Data.Mapping
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.ToTable("Location");
            builder.HasKey(l => l.LocationId);
            builder.Property(l => l.Country).IsRequired();
            builder.Property(l => l.Region).IsRequired();
            builder.Property(l => l.City).IsRequired();
            builder.Property(l => l.Street).IsRequired();
            builder.Property(l => l.StreetNr).IsRequired();
            builder.Property(l => l.ZipCode).IsRequired();
        }

    }
}
