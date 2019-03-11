using Microsoft.EntityFrameworkCore;
using PsyGardenBackEnd.Data.Mapping;
using PsyGardenBackEnd.Models.Domain;

namespace PsyGardenBackEnd.Data
{
    public class PsyGardenDBContext : DbContext
    {
        public PsyGardenDBContext(DbContextOptions<PsyGardenDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new EventConfiguration());
            modelBuilder.ApplyConfiguration(new LocationConfiguration());
            modelBuilder.ApplyConfiguration(new PriceConfiguration());
            modelBuilder.ApplyConfiguration(new ResourceConfiguration());
            modelBuilder.ApplyConfiguration(new LinkConfiguration());
            modelBuilder.ApplyConfiguration(new ImageConfiguration());
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Location> Locations { get; set; }
    }
}
