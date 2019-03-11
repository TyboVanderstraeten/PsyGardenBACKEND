using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsyGardenBackEnd.Models.Domain
{
    public class Location
    {
        public Country Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string  Street { get; set; }
        public string StreetNr { get; set; }
        public string ZipCode { get; set; }
    }
}
