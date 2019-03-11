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
        public int NrOfDays { get { return (EndDate - StartDate).Days; } }
        public Location Location { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public ICollection<Price> Prices { get; set; }
        public ICollection<Resource> Resources { get; set; }
        #endregion

        protected Event()
        {

        }

        public Event(string name, string description, DateTime startDate, DateTime endDate, Location location)
        {
            Name = name;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            Location = location;
            Genres = new List<Genre>();
            Prices = new List<Price>();
            Resources = new List<Resource>();
        }
    }
}
