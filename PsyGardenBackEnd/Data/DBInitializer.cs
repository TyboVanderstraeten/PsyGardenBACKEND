using PsyGardenBackEnd.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsyGardenBackEnd.Data
{
    public class DBInitializer
    {
        private PsyGardenDBContext _dbContext;
        private IEventRepository _eventRepository;
        private IGenreRepository _genreRepository;

        public DBInitializer(PsyGardenDBContext dbContext, IEventRepository eventRepository,
            IGenreRepository genreRepository)
        {
            _dbContext = dbContext;
            _eventRepository = eventRepository;
            _genreRepository = genreRepository;
        }

        public void InitializeData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated()) {
                ////Some genres
                //Genre goaTrance = new Genre("GoaTrance");
                //Genre psyTrance = new Genre("PsyTrance");
                //Genre uptempoPsy = new Genre("FullOnTrance");
                //Genre hitech = new Genre("Hitech");

                ////Adding genres to DB
                //_genreRepository.Add(goaTrance);
                //_genreRepository.Add(psyTrance);
                //_genreRepository.Add(uptempoPsy);
                //_genreRepository.Add(hitech);
                //_genreRepository.SaveChanges();

                ////Some prices
                //Price standardPrice = new Price("The standard price", 20.0M);
                //Price earlyBirdPrice = new Price("The early bird price", 14.5M);
                //Price VIPPrice = new Price("The VIP price", 45.0M);

                ////Some resources
                //Resource websiteLink = new Link("Website", "www.psyfest.com");
                //Resource ticketLink = new Link("Tickets", "www.psyfest.tickets.com");

                ////Location
                //Location location = new Location(Country.Portugal, "Idanha-a-Nova",
                //   "Herdade do Torrão", "Lasientas", "440", "14500");

                ////Event
                //Event psyfest = new Event("Psyfest", "The annual psytrance gathering", new DateTime(2019, 8, 20),
                //    new DateTime(2019, 8, 24), location);
                //psyfest.AddGenre(psyTrance);
                //psyfest.AddGenre(hitech);
                //psyfest.AddPrice(standardPrice);
                //psyfest.AddPrice(earlyBirdPrice);
                //psyfest.AddPrice(VIPPrice);
                //psyfest.AddResource(websiteLink);
                //psyfest.AddResource(ticketLink);

                ////Adding to repo + saving context to DB
                //_eventRepository.Add(psyfest);
                //_eventRepository.SaveChanges();
            }
        }
    }
}
