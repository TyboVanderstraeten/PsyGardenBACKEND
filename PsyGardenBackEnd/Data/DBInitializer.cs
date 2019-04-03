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


        public DBInitializer(PsyGardenDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void InitializeData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated()) {
                //Some genres
                Genre chillOut = new Genre("Chill out");
                Genre goa = new Genre("Goa");
                Genre suomiSoundi = new Genre("Suomi soundi");
                Genre darkRoots = new Genre("Dark roots");
                Genre psytrance = new Genre("Psytrance");
                Genre progressivePsytrance = new Genre("Progressive Psytrance");
                Genre hitech = new Genre("Hitech");
                Genre fullOn = new Genre("Full on");
                Genre forest = new Genre("Forest");
                Genre darkPsytrance = new Genre("Dark psytrance");
                Genre zenonseque = new Genre("Zenonseque");
                Genre psyTech = new Genre("Psy tech");
                Genre techno = new Genre("Techno");
                Genre acid303 = new Genre("Acid 303");
                Genre twilightSounds = new Genre("Twilight sounds");
                Genre minimal = new Genre("Minimal");
                Genre ethnicChill = new Genre("Ethnic chill");
                Genre nitzhogoa = new Genre("Nitzhogoa");
                Genre other = new Genre("Other");

                //Adding genres to DB
                _dbContext.Genres.Add(chillOut);
                _dbContext.Genres.Add(goa);
                _dbContext.Genres.Add(suomiSoundi);
                _dbContext.Genres.Add(darkRoots);
                _dbContext.Genres.Add(psytrance);
                _dbContext.Genres.Add(progressivePsytrance);
                _dbContext.Genres.Add(hitech);
                _dbContext.Genres.Add(fullOn);
                _dbContext.Genres.Add(forest);
                _dbContext.Genres.Add(darkPsytrance);
                _dbContext.Genres.Add(zenonseque);
                _dbContext.Genres.Add(psyTech);
                _dbContext.Genres.Add(techno);
                _dbContext.Genres.Add(acid303);
                _dbContext.Genres.Add(twilightSounds);
                _dbContext.Genres.Add(minimal);
                _dbContext.Genres.Add(ethnicChill);
                _dbContext.Genres.Add(nitzhogoa);
                _dbContext.Genres.Add(other);
                _dbContext.SaveChanges();

                //Some prices
                Price standardPrice1 = new Price("Standard", "The standard price", 20.0M);
                Price earlyBirdPrice1 = new Price("Early bird", "The early bird price", 14.5M);
                Price VIPPrice1 = new Price("VIP", "The VIP price", 45.0M);

                Price standardPrice2 = new Price("Standard", "The standard price", 20.0M);
                Price earlyBirdPrice2 = new Price("Early bird", "The early bird price", 14.5M);
                Price VIPPrice2 = new Price("VIP", "The VIP price", 45.0M);

                Price standardPrice3 = new Price("Standard", "The standard price", 20.0M);
                Price earlyBirdPrice3 = new Price("Early bird", "The early bird price", 14.5M);
                Price VIPPrice3 = new Price("VIP", "The VIP price", 45.0M);

                Price standardPrice4 = new Price("Standard", "The standard price", 20.0M);
                Price earlyBirdPrice4 = new Price("Early bird", "The early bird price", 14.5M);
                Price VIPPrice4 = new Price("VIP", "The VIP price", 45.0M);

                //Some resources
                Resource websiteLink1 = new Link("Website", "www.psyfest.com");
                Resource ticketLink1 = new Link("Tickets", "www.psyfest.tickets.com");
                Resource headerImage1 = new Image("Header", "header.jpg", "header image");

                Resource websiteLink2 = new Link("Website", "www.psyfest.com");
                Resource ticketLink2 = new Link("Tickets", "www.psyfest.tickets.com");
                Resource headerImage2 = new Image("Header", "header.jpg", "header image");

                Resource websiteLink3 = new Link("Website", "www.psyfest.com");
                Resource ticketLink3 = new Link("Tickets", "www.psyfest.tickets.com");
                Resource headerImage3 = new Image("Header", "header.jpg", "header image");

                Resource websiteLink4 = new Link("Website", "www.psyfest.com");
                Resource ticketLink4 = new Link("Tickets", "www.psyfest.tickets.com");
                Resource headerImage4 = new Image("Header", "header.jpg", "header image");

                //Event
                Event event1 = new Event("Psyfest", "The annual psytrance gathering", new DateTime(2019, 8, 20),
                    new DateTime(2019, 8, 24), Country.Portugal, "Idanha-a-Nova",
                   "Herdade do Torrão", "Lasientas", "440", "14500");
                event1.AddEventGenre(psytrance);
                event1.AddEventGenre(nitzhogoa);
                event1.AddEventGenre(fullOn);
                event1.AddEventGenre(techno);
                event1.AddPrice(standardPrice1);
                event1.AddPrice(earlyBirdPrice1);
                event1.AddPrice(VIPPrice1);
                event1.AddResource(websiteLink1);
                event1.AddResource(ticketLink1);
                event1.AddResource(headerImage1);

                Event event2 = new Event("Ozora", "Hungary's best psychedelic gathering", new DateTime(2019, 9, 20),
                new DateTime(2019, 9, 30), Country.Hungary, "Sdzopky",
                "Tzorde dagia", "Slozt", "8", "1244");
                event2.AddEventGenre(darkPsytrance);
                event2.AddEventGenre(nitzhogoa);
                event2.AddEventGenre(fullOn);
                event2.AddEventGenre(techno);
                event2.AddPrice(standardPrice2);
                event2.AddPrice(earlyBirdPrice2);
                event2.AddPrice(VIPPrice2);
                event2.AddResource(websiteLink2);
                event2.AddResource(ticketLink2);
                event2.AddResource(headerImage2);

                Event event3 = new Event("Space Safari", "Come meet us under the sun!", new DateTime(2019, 7, 12),
                new DateTime(2019, 7, 14), Country.Belgium, "Henegouwen",
                "Namen", "Bergstraat", "1", "7000");
                event3.AddEventGenre(psyTech);
                event3.AddEventGenre(psytrance);
                event3.AddEventGenre(nitzhogoa);
                event3.AddEventGenre(fullOn);
                event3.AddEventGenre(techno);
                event3.AddPrice(standardPrice3);
                event3.AddPrice(earlyBirdPrice3);
                event3.AddPrice(VIPPrice3);
                event3.AddResource(websiteLink3);
                event3.AddResource(ticketLink3);
                event3.AddResource(headerImage3);

                Event event4 = new Event("Connections", "Connect with eachother", new DateTime(2019, 8, 2),
                new DateTime(2019, 8, 8), Country.Spain, "Madrid",
                "Lopez", "Avenua constricto", "877", "84100");
                event4.AddEventGenre(zenonseque);
                event4.AddEventGenre(nitzhogoa);
                event4.AddEventGenre(goa);
                event4.AddEventGenre(darkPsytrance);
                event4.AddEventGenre(darkRoots);
                event4.AddPrice(standardPrice4);
                event4.AddPrice(earlyBirdPrice4);
                event4.AddPrice(VIPPrice4);
                event4.AddResource(websiteLink4);
                event4.AddResource(ticketLink4);
                event4.AddResource(headerImage4);

                //Adding to repo + saving context to DB
                _dbContext.Events.Add(event1);
                _dbContext.Events.Add(event2);
                _dbContext.Events.Add(event3);
                _dbContext.Events.Add(event4);
                _dbContext.SaveChanges();
            }
        }
    }
}
