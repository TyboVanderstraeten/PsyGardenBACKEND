using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PsyGardenBackEnd.Data.Mapping;
using PsyGardenBackEnd.Models.Domain;
using System;

namespace PsyGardenBackEnd.Data
{
    public class PsyGardenDBContext : IdentityDbContext
    {
        public PsyGardenDBContext(DbContextOptions<PsyGardenDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new EventConfiguration());
            modelBuilder.ApplyConfiguration(new PriceConfiguration());
            modelBuilder.ApplyConfiguration(new LinkConfiguration());
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new EventGenreConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserInterestedConfiguration());
            modelBuilder.ApplyConfiguration(new UserGoingConfiguration());
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
