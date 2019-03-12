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

        public DBInitializer(PsyGardenDBContext dbContext, IEventRepository eventRepository)
        {
            _dbContext = dbContext;
            _eventRepository = eventRepository;
        }

        public void InitializeData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated()) {
                //Some prices
                Price standardPrice = new Price("The standard price", 20.0M);
                Price earlyBirdPrice = new Price("The early bird price", 14.5M);
                Price VIPPrice = new Price("The VIP price", 45.0M);

                //Some resources
                Resource websiteLink = new Link("Website", "www.psyfest.com");
                Resource ticketLink = new Link("Tickets", "www.psyfest.tickets.com");

                //Location
                Location location = new Location(Country.Portugal, "Idanha-a-Nova",
                   "Herdade do Torrão", "Lasientas", "440", "14500");

                //Event
                Event psyfest = new Event("Psyfest", "The annual psytrance gathering", new DateTime(2019, 8, 20),
                    new DateTime(2019, 8, 24), location);
                psyfest.AddGenre(Genre.DarkPsy);
                psyfest.AddGenre(Genre.HiTech);
                psyfest.AddGenre(Genre.PsyTrance);
                psyfest.AddPrice(standardPrice);
                psyfest.AddPrice(earlyBirdPrice);
                psyfest.AddPrice(VIPPrice);
                psyfest.AddResource(websiteLink);
                psyfest.AddResource(ticketLink);

                //Adding to repo + saving context to DB
                _eventRepository.Add(psyfest);
                _eventRepository.SaveChanges();
                Console.WriteLine(_eventRepository.GetById(1).Location.Country);
                Console.ReadLine();
            }
        }
    }
}
