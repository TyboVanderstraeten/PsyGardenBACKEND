using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PsyGardenBackEnd.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsyGardenBackEnd.Data.Mapping
{
    public class UserInterestedConfiguration : IEntityTypeConfiguration<UserInterested>
    {
        public void Configure(EntityTypeBuilder<UserInterested> builder)
        {
            builder.ToTable("UserInterested");
            builder.HasKey(ui => new { ui.UserId, ui.EventId });
        }
    }
}
