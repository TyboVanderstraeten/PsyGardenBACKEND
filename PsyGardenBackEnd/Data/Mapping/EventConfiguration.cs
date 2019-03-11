using Microsoft.EntityFrameworkCore;
using PsyGardenBackEnd.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsyGardenBackEnd.Data.Mapping
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("Event");
            builder.HasKey(e => e.EventId);
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.Description).IsRequired();
            builder.Property(e => e.StartDate).IsRequired();
            builder.Property(e => e.EndDate).IsRequired();
            builder.Ignore(e => e.Genres);
            builder.HasOne(e => e.Location).WithMany().IsRequired().OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(e => e.Prices).WithOne().IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(e => e.Resources).WithOne().IsRequired().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
