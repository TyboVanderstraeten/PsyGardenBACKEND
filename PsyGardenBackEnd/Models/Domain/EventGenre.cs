using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsyGardenBackEnd.Models.Domain
{
    [JsonObject(MemberSerialization.OptIn)]
    public class EventGenre
    {
        #region Properties
        public int EventId { get; set; }
        public int GenreId { get; set; }
        [JsonProperty]
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
            Genre = genre;
        }
        #endregion
    }
}
