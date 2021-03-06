﻿using Microsoft.EntityFrameworkCore;
using PsyGardenBackEnd.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsyGardenBackEnd.Data.Mapping
{
    public class EventGenreConfiguration : IEntityTypeConfiguration<EventGenre>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<EventGenre> builder)
        {
            builder.ToTable("EventGenre");
            builder.HasKey(eg => new { eg.EventId, eg.GenreId });
            builder.HasOne(eg => eg.Genre).WithMany()
            .IsRequired(true).HasForeignKey(e => e.GenreId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
