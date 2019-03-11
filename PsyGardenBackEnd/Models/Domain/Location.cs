using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsyGardenBackEnd.Models.Domain
{
    public class Location
    {
        public int LocationId { get; set; }
        public Country Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string StreetNr { get; set; }
        public string ZipCode { get; set; }

        protected Location()
        {

        }

        public Location(Country country, string region, string city, string street, string streetnr, string zipcode)
        {
            Country = Country;
            Region = region;
            City = city;
            Street = street;
            StreetNr = streetnr;
            ZipCode = zipcode;
        }
    }
}
