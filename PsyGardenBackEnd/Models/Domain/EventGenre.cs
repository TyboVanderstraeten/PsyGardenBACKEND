using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsyGardenBackEnd.Models.Domain
{
    public class EventGenre
    {
        #region Properties
        public int EventId { get; set; }
        public int GenreId { get; set; }
        public Event Event { get; set; }
        public Genre Genre { get; set; }
        #endregion

        #region Constructors
        public EventGenre()
        {

        }

        public EventGenre(Event @event, Genre genre)
        {
            EventId = @event.EventId;
            GenreId = genre.GenreId;
            Event = @event;
            Genre = genre;
        } 
        #endregion
    }
}
