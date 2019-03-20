﻿using System;
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
        public Country Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string StreetNr { get; set; }
        public string ZipCode { get; set; }
        public ICollection<EventGenre> Genres { get; set; }
        public ICollection<Price> Prices { get; set; }
        public ICollection<Resource> Resources { get; set; }
        #endregion

        #region Constructors
        public Event()
        {
            Genres = new List<EventGenre>();
            Prices = new List<Price>();
            Resources = new List<Resource>();
        }

        public Event(string name, string description, DateTime startDate, DateTime endDate,
            Country country, string region, string city, string street, string streetnr,
            string zipcode)
        {
            Name = name;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            Country = Country;
            Region = region;
            City = city;
            Street = street;
            StreetNr = streetnr;
            ZipCode = zipcode;
            Genres = new List<EventGenre>();
            Prices = new List<Price>();
            Resources = new List<Resource>();
        }
        #endregion

        #region Methods
        public void AddGenre(Genre genre)
        {
            EventGenre eventGenre = new EventGenre(this, genre);
            Genres.Add(eventGenre);
        }

        public void RemoveGenre(Genre genre)
        {
            EventGenre eventGenre = new EventGenre(this, genre);
            Genres.Remove(eventGenre);
        }

        public void AddPrice(Price price)
        {
            Prices.Add(price);
        }

        public void RemovePrice(Price price)
        {
            Prices.Remove(price);
        }

        public void AddResource(Resource resource)
        {
            Resources.Add(resource);
        }

        public void RemoveResource(Resource resource)
        {
            Resources.Remove(resource);
        }
        #endregion
    }
}
