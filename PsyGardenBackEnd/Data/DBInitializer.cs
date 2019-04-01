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
                Price standardPrice = new Price("Standard", "The standard price", 20.0M);
                Price earlyBirdPrice = new Price("Early bird", "The early bird price", 14.5M);
                Price VIPPrice = new Price("VIP", "The VIP price", 45.0M);

                //Some resources
                Resource websiteLink = new Link("Website", "www.psyfest.com");
                Resource ticketLink = new Link("Tickets", "www.psyfest.tickets.com");
                Resource headerImage = new Image("Header", "header.jpg", "header image");

                //Event
                Event psyfest = new Event("Psyfest", "The annual psytrance gathering", new DateTime(2019, 8, 20),
                    new DateTime(2019, 8, 24), Country.Portugal, "Idanha-a-Nova",
                   "Herdade do Torrão", "Lasientas", "440", "14500");
                psyfest.AddEventGenre(psytrance);
                psyfest.AddEventGenre(nitzhogoa);
                psyfest.AddEventGenre(fullOn);
                psyfest.AddEventGenre(techno);
                psyfest.AddPrice(standardPrice);
                psyfest.AddPrice(earlyBirdPrice);
                psyfest.AddPrice(VIPPrice);
                psyfest.AddResource(websiteLink);
                psyfest.AddResource(ticketLink);
                psyfest.AddResource(headerImage);

                //Adding to repo + saving context to DB
                _dbContext.Events.Add(psyfest);
                _dbContext.SaveChanges();
            }
        }
    }
}
