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
                #region GENRES
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
                #endregion

                #region PRICES
                //Some prices
                //PsyFi
                Price presale1stPhasePF = new Price("1st Phase tickets", "The price for 1st phase tickets", 112.50M);
                Price presale2ndPhasePF = new Price("2nd Phase tickets", "The price for 2nd phase tickets", 132.50M);
                Price presale3rdPhasePF = new Price("3rd Phase tickets", "The price for 3rd phase tickets", 152.50M);
                Price gatesFullWeekPF = new Price("Full week (gates)", "The price for the full week", 170.0M);
                Price gatesWeekendPF = new Price("Saturday + Sunday (gates)", "The price for the weekend", 90.0M);
                Price gatesSundayPF = new Price("Sunday (gates)", "The price for Sunday", 60.0M);

                //Ozora
                Price ticketPriceO = new Price("Standard ticket", "The standard price", 194.0M);

                //SpaceSafari
                Price presale1stPhaseSS = new Price("1st Phase tickets", "The price for 1st phase tickets", 70.0M);
                Price presale2ndPhaseSS = new Price("2nd Phase tickets", "The price for 2nd phase tickets", 80.0M);
                Price presale3rdPhaseSS = new Price("3rd Phase tickets", "The price for 3rd phase tickets", 90.0M);

                //Boom
                Price unknownB = new Price("No tickets yet", "There are no tickets yet", 0.0M);

                #endregion

                #region Links
                //Some resources
                Link websitePsyFi = new Link("Website", "www.psy-fi.nl");
                Link ticketsPsyFi = new Link("Tickets", "www.psy-fi.nl/tickets");

                Link websiteOzora = new Link("Website", "ozorafestival.eu");
                Link ticketsOzora = new Link("Tickets", "ozorafestival.eu/tickets/buy-a-ticket-here/");

                Link websiteSpaceSafari = new Link("Website", "www.space-safari.com");
                Link ticketsSpaceSafari = new Link("Tickets", "www.space-safari.com/tickets/");

                Link websiteBoom = new Link("Website", "www.boomfestival.org/boom2018/");
                Link ticketsBoom = new Link("Tickets", "www.boomfestival.org/boom2018/tickets/");
                #endregion

                #region EVENTS
                //Event
                Event psyFi = new Event("Psy-Fi", "Seed of Science", new DateTime(2019, 8, 28, 8, 0, 0),
                    new DateTime(2019, 9, 1, 23, 0, 0), "Netherlands",null,
                   "Leeuwarden", "De Groene Ster", null, "8926","img.jpg");
                psyFi.AddEventGenre(psytrance);
                psyFi.AddEventGenre(nitzhogoa);
                psyFi.AddEventGenre(fullOn);
                psyFi.AddEventGenre(techno);
                psyFi.AddPrice(presale1stPhasePF);
                psyFi.AddPrice(presale2ndPhasePF);
                psyFi.AddPrice(presale3rdPhasePF);
                psyFi.AddPrice(gatesFullWeekPF);
                psyFi.AddPrice(gatesWeekendPF);
                psyFi.AddPrice(gatesSundayPF);
                psyFi.AddLink(websitePsyFi);
                psyFi.AddLink(ticketsPsyFi);

                Event ozora = new Event("Ozora Festival", "The Ozora Festival, stylised as O.Z.O.R.A",
                    new DateTime(2019, 7, 29, 21, 0, 0),
                    new DateTime(2019, 8, 4, 21, 0, 0), "Hungary", "Ozora", "Dádpuszta", "Dádpuszta", "7015", "7086","img.jpg");
                ozora.AddEventGenre(darkPsytrance);
                ozora.AddEventGenre(nitzhogoa);
                ozora.AddEventGenre(fullOn);
                ozora.AddEventGenre(techno);
                ozora.AddPrice(ticketPriceO);
                ozora.AddLink(websiteOzora);
                ozora.AddLink(ticketsOzora);

                Event spaceSafari = new Event("Space Safari", "Come meet us under the sun!", new DateTime(2019, 8, 30, 14, 0, 0),
                new DateTime(2019, 9, 2, 14, 0, 0), "Belgium", "Namen",
                   "Massembre", "Domaine De Massembre", null, "5543","img.jpg");
                spaceSafari.AddEventGenre(psyTech);
                spaceSafari.AddEventGenre(psytrance);
                spaceSafari.AddEventGenre(nitzhogoa);
                spaceSafari.AddEventGenre(fullOn);
                spaceSafari.AddEventGenre(techno);
                spaceSafari.AddPrice(presale1stPhaseSS);
                spaceSafari.AddPrice(presale2ndPhaseSS);
                spaceSafari.AddPrice(presale3rdPhaseSS);
                spaceSafari.AddLink(websiteSpaceSafari);
                spaceSafari.AddLink(ticketsSpaceSafari);

                Event boom = new Event("Boom", "Connect with eachother", new DateTime(2020, 7, 28, 0, 0, 0),
                new DateTime(2020, 8, 4, 0, 0, 0), "Portugal", "Castelo Branco",
                   "Idanha-a-Nova", "Boomland Alcafozes", null, "6060-011","img.jpg");
                boom.AddEventGenre(zenonseque);
                boom.AddEventGenre(nitzhogoa);
                boom.AddEventGenre(goa);
                boom.AddEventGenre(darkPsytrance);
                boom.AddEventGenre(darkRoots);
                boom.AddPrice(unknownB);
                boom.AddLink(websiteBoom);
                boom.AddLink(ticketsBoom);
                #endregion

                //Adding to repo + saving context to DB
                _dbContext.Events.Add(psyFi);
                _dbContext.Events.Add(ozora);
                _dbContext.Events.Add(spaceSafari);
                _dbContext.Events.Add(boom);
                _dbContext.SaveChanges();
            }
        }
    }
}
