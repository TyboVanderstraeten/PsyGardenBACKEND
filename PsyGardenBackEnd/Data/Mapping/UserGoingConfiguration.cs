using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PsyGardenBackEnd.Models.Domain;


namespace PsyGardenBackEnd.Data.Mapping
{
    public class UserGoingConfiguration : IEntityTypeConfiguration<UserGoing>
    {
        public void Configure(EntityTypeBuilder<UserGoing> builder)
        {
            builder.ToTable("UserGoing");
            builder.HasKey(ug => new { ug.UserId, ug.EventId });
        }
    }
}
