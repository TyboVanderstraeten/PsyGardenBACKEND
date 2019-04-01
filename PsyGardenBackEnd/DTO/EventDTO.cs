using PsyGardenBackEnd.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsyGardenBackEnd.DTO
{
    public class EventDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Country Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string StreetNr { get; set; }
        public string ZipCode { get; set; }
        public IList<EventGenreDTO> Genres { get; set; }
        public IList<PriceDTO> Prices { get; set; }
        public IList<ResourceDTO> Resources { get; set; }
    }
}
