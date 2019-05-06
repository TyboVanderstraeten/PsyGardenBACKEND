﻿using Microsoft.AspNetCore.Identity;
using PsyGardenBackEnd.Models.Domain;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PsyGardenBackEnd.Data
{
    public class DBInitializer
    {
        private PsyGardenDBContext _dbContext;
        private UserManager<IdentityUser> _userManager;

        public DBInitializer(PsyGardenDBContext dbContext, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task InitializeData()
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

                #region LINKS
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
                    new DateTime(2019, 9, 1, 23, 0, 0), "Netherlands", null,
                   "Leeuwarden", "De Groene Ster", null, "8926", "https://static1.squarespace.com/static/52e562c3e4b04ab8b0fbe97d/56ef528bd210b8dcd0ac1675/56ef528b22482e26f27c3585/1458524828107/Fractalfest2015_2528.jpg?format=1500w");
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
                    new DateTime(2019, 8, 4, 21, 0, 0), "Hungary", "Ozora", "Dádpuszta", "Dádpuszta", "7015", "7086", "https://static1.squarespace.com/static/52e562c3e4b04ab8b0fbe97d/56ef528bd210b8dcd0ac1675/56ef528b22482e26f27c3585/1458524828107/Fractalfest2015_2528.jpg?format=1500w");
                ozora.AddEventGenre(darkPsytrance);
                ozora.AddEventGenre(nitzhogoa);
                ozora.AddEventGenre(fullOn);
                ozora.AddEventGenre(techno);
                ozora.AddPrice(ticketPriceO);
                ozora.AddLink(websiteOzora);
                ozora.AddLink(ticketsOzora);

                Event spaceSafari = new Event("Space Safari", "Come meet us under the sun!", new DateTime(2019, 8, 30, 14, 0, 0),
                new DateTime(2019, 9, 2, 14, 0, 0), "Belgium", "Namen",
                   "Massembre", "Domaine De Massembre", null, "5543", "https://static1.squarespace.com/static/52e562c3e4b04ab8b0fbe97d/56ef528bd210b8dcd0ac1675/56ef528b22482e26f27c3585/1458524828107/Fractalfest2015_2528.jpg?format=1500w");
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
                   "Idanha-a-Nova", "Boomland Alcafozes", null, "6060-011", "https://static1.squarespace.com/static/52e562c3e4b04ab8b0fbe97d/56ef528bd210b8dcd0ac1675/56ef528b22482e26f27c3585/1458524828107/Fractalfest2015_2528.jpg?format=1500w");
                boom.AddEventGenre(zenonseque);
                boom.AddEventGenre(nitzhogoa);
                boom.AddEventGenre(goa);
                boom.AddEventGenre(darkPsytrance);
                boom.AddEventGenre(darkRoots);
                boom.AddPrice(unknownB);
                boom.AddLink(websiteBoom);
                boom.AddLink(ticketsBoom);

                _dbContext.Events.Add(psyFi);
                _dbContext.Events.Add(ozora);
                _dbContext.Events.Add(spaceSafari);
                _dbContext.Events.Add(boom);
                #endregion

                #region USERS
                User admin = new User("Tybo", "Vanderstraeten", "tybo.admin@psygarden.com");
                admin.IsAdmin = true;
                admin.AddInterested(psyFi);
                admin.AddInterested(ozora);
                admin.AddGoing(spaceSafari);

                User normalUser = new User("Tim", "Geldof", "tim@psygarden.com");
                normalUser.AddInterested(ozora);
                normalUser.AddGoing(boom);

                _dbContext.Users.Add(admin);
                _dbContext.Users.Add(normalUser);

                await CreateIdentityUser(admin);
                await CreateIdentityUser(normalUser);
                #endregion

                _dbContext.SaveChanges();
            }
        }

        private async Task CreateIdentityUser(User user)
        {
            IdentityUser identityUser = new IdentityUser() { UserName = user.Email, Email = user.Email };
            await _userManager.CreateAsync(identityUser, "P@ssword1");
            if (user.IsAdmin) {
                await _userManager.AddClaimAsync(identityUser, new Claim(ClaimTypes.Role, "admin"));
            }
            else {
                await _userManager.AddClaimAsync(identityUser, new Claim(ClaimTypes.Role, "user"));
            }
            _dbContext.SaveChanges();
        }
    }
}
