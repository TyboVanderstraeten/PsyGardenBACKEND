using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsyGardenBackEnd.Models.Domain
{
    public class Event
    {
        #region Backingfields
        private string _name;
        private string _description;
        private DateTime _startDate;
        private DateTime _endDate;
        private string _country;
        private string _region;
        private string _city;
        private string _street;
        private string _streetNr;
        private string _zipCode;
        private string _headerImageURL;
        #endregion

        #region Properties
        public int EventId { get; set; }

        public string Name {
            get { return _name; }
            set {
                if (value == null || value.Equals(String.Empty)) {
                    throw new ArgumentException("Name is required");
                }
                else if (value.Length > 50) {
                    throw new ArgumentException("Name contains 50 chars. max");
                }
                else {
                    _name = value;
                }
            }
        }

        public string Description {
            get { return _description; }
            set {
                if (value == null | value.Equals(String.Empty)) {
                    throw new ArgumentException("Description is required");
                }
                else {
                    _description = value;
                }
            }
        }

        public DateTime StartDate {
            get { return _startDate; }
            set {
                if (value == null) {
                    throw new ArgumentException("Startdate is required");
                }
                else if (value.CompareTo(DateTime.Now) < 0) {
                    throw new ArgumentException("Startdate can't be in the past");
                }
                else {
                    _startDate = value;
                }
            }
        }

        public DateTime EndDate {
            get { return _endDate; }
            set {
                if (value == null) {
                    throw new ArgumentException("Enddate is required");
                }
                else if (value.CompareTo(DateTime.Now) < 0) {
                    throw new ArgumentException("Enddate can't be in the past");
                }
                else if (value.CompareTo(StartDate) < 0) {
                    throw new ArgumentException("Enddate can't lay before startdate");
                }
                else {
                    _endDate = value;
                }
            }
        }

        public int NrOfDays { get { return (EndDate - StartDate).Days + 1; } }

        public string Country {
            get { return _country; }
            set {
                if (value == null || value.Equals(String.Empty)) {
                    throw new ArgumentException("Country is required");
                }
                else if (value.Length > 100) {
                    throw new ArgumentException("Country contains 100 chars. max");
                }
                else {
                    _country = value;
                }
            }
        }

        public string Region {
            get { return _region; }
            set {
                if (value != null) {
                    if (value.Length > 100) {
                        throw new ArgumentException("Region contains 100 chars. max");
                    }
                    else {
                        _region = value;
                    }
                }
            }
        }

        public string City {
            get { return _city; }
            set {
                if (value == null || value.Equals(String.Empty)) {
                    throw new ArgumentException("City is required");
                }
                else if (value.Length > 100) {
                    throw new ArgumentException("City contains 100 chars. max");
                }
                else {
                    _city = value;
                }
            }
        }

        public string Street {
            get { return _street; }
            set {
                if (value == null || value.Equals(String.Empty)) {
                    throw new ArgumentException("Street is required");
                }
                else if (value.Length > 100) {
                    throw new ArgumentException("Street contains 100 chars. max");
                }
                else {
                    _street = value;
                }
            }
        }

        public string StreetNr {
            get { return _streetNr; }
            set {
                if (value != null) {
                    if (value.Length > 10) {
                        throw new ArgumentException("Street number contains 10 chars. max");
                    }
                    else {
                        _streetNr = value;
                    }
                }
            }
        }

        public string ZipCode {
            get { return _zipCode; }
            set {
                if (value == null || value.Equals(String.Empty)) {
                    throw new ArgumentException("Zipcode is required");
                }
                else if (value.Length > 10) {
                    throw new ArgumentException("Zipcode contains 10 chars. max");
                }
                else {
                    _zipCode = value;
                }
            }
        }

        public string HeaderImageURL {
            get { return _headerImageURL; }
            set {
                if (value == null || value.Equals(String.Empty)) {
                    throw new ArgumentException("Headerimage-URL is required");
                }
                else if (value.Length > 100) {
                    throw new ArgumentException("Headerimage-URL contains 100 chars. max");
                }
                else {
                    _headerImageURL = value;
                }
            }
        }

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
            string zipcode, string headerImageURL)
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
