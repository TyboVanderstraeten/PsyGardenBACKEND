using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PsyGardenBackEnd.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsyGardenBackEnd.Data.Mapping
{
    public class ResourceConfiguration : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {

            builder.ToTable("Resource");
            builder.HasKey(r => r.ResourceId);
            builder.Property(r => r.Name).IsRequired();
            builder.Property(r => r.Url).IsRequired();
            builder.HasDiscriminator<string>("Type")
                .HasValue<Link>("Link")
                .HasValue<Image>("Image");
        }
    }
}
