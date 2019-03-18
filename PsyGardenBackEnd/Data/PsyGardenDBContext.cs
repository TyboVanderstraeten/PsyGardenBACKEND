using Microsoft.EntityFrameworkCore;
using PsyGardenBackEnd.Data.Mapping;
using PsyGardenBackEnd.Models.Domain;
using System;

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
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new EventGenreConfiguration());

            Location location = new Location(Country.Portugal, "Idanha-a-Nova",
                   "Herdade do Torrão", "Lasientas", "440", "14500");
            location.LocationId = 1;
            Event e = new Event("test", "test", DateTime.Now, DateTime.Now.AddDays(1), location);
            e.EventId = 1;

            modelBuilder.Entity<Event>().HasData(e);
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}
