using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsyGardenBackEnd.Models.Domain
{
    public class Event
    {
        #region Properties
        public int EventId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NrOfDays { get { return (EndDate - StartDate).Days + 1; } }
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string StreetNr { get; set; }
        public string ZipCode { get; set; }
        public string HeaderImageURL { get; set; }
        public ICollection<EventGenre> EventGenres { get; set; }
        public ICollection<Price> Prices { get; set; }
        public ICollection<Link> Links { get; set; }

        #endregion

        #region Constructors
        public Event()
        {
            EventGenres = new List<EventGenre>();
            Prices = new List<Price>();
            Links = new List<Link>();
        }

        public Event(string name, string description, DateTime startDate, DateTime endDate,
            string country, string region, string city, string street, string streetnr,
            string zipcode,string headerImageURL)
        {
            Name = name;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            Country = country;
            Region = region;
            City = city;
            Street = street;
            StreetNr = streetnr;
            ZipCode = zipcode;
            HeaderImageURL = headerImageURL;
            EventGenres = new List<EventGenre>();
            Prices = new List<Price>();
            Links = new List<Link>();
        }
        #endregion

        #region Methods
        public void AddEventGenre(Genre genre)
        {
            EventGenre eventGenre = new EventGenre(this, genre);
            EventGenres.Add(eventGenre);
        }

        public void RemoveEventGenre(Genre genre)
        {
            EventGenre eventGenre = EventGenres.SingleOrDefault(eg => eg.GenreId == genre.GenreId);
            EventGenres.Remove(eventGenre);
        }

        public void AddPrice(Price price)
        {
            Prices.Add(price);
        }

        public void RemovePrice(Price price)
        {
            Prices.Remove(price);
        }

        public void AddLink(Link link)
        {
            Links.Add(link);
        }

        public void RemoveLink(Link link)
        {
            Links.Remove(link);
        }
        #endregion
    }
}
