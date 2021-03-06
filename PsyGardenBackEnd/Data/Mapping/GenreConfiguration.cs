﻿using Microsoft.EntityFrameworkCore;
using PsyGardenBackEnd.Models.Domain;


namespace PsyGardenBackEnd.Data.Mapping
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("Genre");
            builder.HasKey(g => g.GenreId);
            builder.Property(g => g.Name).IsRequired().HasMaxLength(25);
        }
    }
}
