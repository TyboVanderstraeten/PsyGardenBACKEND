using Microsoft.AspNetCore.Identity;
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

                #region Descriptions
                string descriptionPsyFi = "Psy-Fi is an annual open air psychedelic music and arts festival in the Netherlands. The first edition was held" +
                    " in July 2013 in the Stadspark of the city of Groningen; all subsequent editions have been held in recreation area De Groene Ster to the" +
                    " east of Leeuwarden. It is one of the largest international festivals in the Netherlands and attracts thousands of visitors each year," +
                    " with the 2017 edition reporting participants from about 100 different countries.";

                string descriptionOzora = "The Ozora Festival, stylised as O.Z.O.R.A., is an annual psychedelic trance and arts festival in the Hungarian" +
                    " village of Ozora. The festival has been held on an estate in Ozora near the small vilage of Dádpuszta every year since 2004. The first" +
                    " modern music festival held in Ozora was called Solipse and took place during the Solar eclipse of August 11, 1999. Solipse did not get " +
                    " a sequel until the first Ozora Festival was held in 2004. The Ozora Festival is one of the two sizeable psytrance festivals in Hungary (" +
                    " the other being Solar United Natives festival), and is one of the largest psychedelic trance festivals in the world. As of 2016, it annualy" +
                    " attracts close to 60,000 people, similar to Boom Festival in Portugal and Antaris Project in Germany who also reach more than 40,000 visitors" +
                    " every year. Due to its success, several one-day spin-offs from the Ozora Festival have been held in several other countries such as Paris, France" +
                    " and São Paulo, Brazil.";

                string descriptionSpaceSafari = "Space Safari is an annual open air psychedelic music and arts festival in Belgium.";

                string descriptionBoom = "The Boom Festival is a biennial transformational festival in Portugal. The festival features music performances and a broad" +
                    " variety of visual art exhibits. Boom festival began in 1997 as a psychedelic trance music festival with a main stage and a lounge area with mellow" +
                    " 'Chill-Out music'. Now, there are five stages: the Dance Temple, for psytrance and natural trance music; the Alchemy Circle is for many fresh" +
                    " experimental genres, including psytechno, progressive psytrance, house and unique combinations of those; the Sacred Fire stage is for world music" +
                    " and live music performances; the Ambient Source is for chill-out music; the Funky Beach stage is for electronic dance music dee jays and producers." +
                    " Other attractions include sculptures, an art gallery, street theatre, and fire performances. Within the shaded Liminal Village are lectures, yoga classes," +
                    " film screenings, group meditation, and discussions. The Healing Area has group workshops for healing techniques, a pool for water therapy and a massage area.";
                #endregion

                Event psyFi = new Event("Psy-Fi", descriptionPsyFi, new DateTime(2019, 8, 28, 8, 0, 0),
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

                Event ozora = new Event("Ozora Festival", descriptionOzora,
                    new DateTime(2019, 7, 29, 21, 0, 0),
                    new DateTime(2019, 8, 4, 21, 0, 0), "Hungary", "Ozora", "Dádpuszta", "Dádpuszta", "7015", "7086", "https://i.redd.it/u4zwhkeca6j01.jpg");
                ozora.AddEventGenre(darkPsytrance);
                ozora.AddEventGenre(nitzhogoa);
                ozora.AddEventGenre(fullOn);
                ozora.AddEventGenre(techno);
                ozora.AddPrice(ticketPriceO);
                ozora.AddLink(websiteOzora);
                ozora.AddLink(ticketsOzora);

                Event spaceSafari = new Event("Space Safari", descriptionSpaceSafari, new DateTime(2019, 8, 30, 14, 0, 0),
                new DateTime(2019, 9, 2, 14, 0, 0), "Belgium", "Namen",
                   "Massembre", "Domaine De Massembre", null, "5543", "http://freebornaiden.com/wp-content/uploads/2018/06/11890403_395297293997496_6413516115231520679_o.jpg");
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

                Event boom = new Event("Boom", descriptionBoom, new DateTime(2020, 7, 28, 0, 0, 0),
                new DateTime(2020, 8, 4, 0, 0, 0), "Portugal", "Castelo Branco",
                   "Idanha-a-Nova", "Boomland Alcafozes", null, "6060-011", "https://europebookings.com/wp-content/uploads/boom-festival-magic-lights-main-stage.jpg");
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

                User web4User = new User("Karine", "Samyn", "web4@psygarden.com");

                _dbContext.Users.Add(admin);
                _dbContext.Users.Add(normalUser);
                _dbContext.Users.Add(web4User);

                await CreateIdentityUser(admin);
                await CreateIdentityUser(normalUser);
                await CreateIdentityUser(web4User);
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

        private async Task CreateWeb4IdentityUser(User user)
        {
            IdentityUser identityUser = new IdentityUser() { UserName = user.Email, Email = user.Email };
            await _userManager.CreateAsync(identityUser, "Gelukkiggeennetbeans123");
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
