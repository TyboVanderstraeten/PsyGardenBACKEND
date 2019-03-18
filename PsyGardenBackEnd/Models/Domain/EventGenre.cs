using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsyGardenBackEnd.Models.Domain
{
    public class EventGenre
    {
        public int EventId { get; set; }
        public int GenreId { get; set; }
        public Event Event { get; set; }
        public Genre Genre { get; set; }

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
    }
}
