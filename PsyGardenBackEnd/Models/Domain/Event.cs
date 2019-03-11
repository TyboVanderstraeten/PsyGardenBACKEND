using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsyGardenBackEnd.Models.Domain
{
    public class Event
    {

        #region Properties
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NrOfDays { get { return (EndDate - StartDate).Days; } }
        public Location Location { get; set; }
        public Genre Genre { get; set; }

        public ICollection<Price> Prices;
        public ICollection<Resource> Resources;
        #endregion

        protected Event()
        {

        }

        public Event(string name, string description, DateTime startDate, DateTime endDate, Location location, Genre genre)
        {
            Name = name;
            Description = description;
            StartDate = startDate;
            EndDate = EndDate;
            Location = location;
            Genre = genre;
        }
    }
}
