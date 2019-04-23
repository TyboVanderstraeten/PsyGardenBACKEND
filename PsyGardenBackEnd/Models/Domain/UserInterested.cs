using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsyGardenBackEnd.Models.Domain
{
    [JsonObject(MemberSerialization.OptIn)]
    public class UserInterested
    {
        #region Properties
        public int UserId { get; set; }
        public int EventId { get; set; }
        [JsonProperty]
        public Event Event { get; set; }
        #endregion

        #region Constructors
        public UserInterested()
        {

        }

        public UserInterested(User user, Event @event)
        {
            UserId = user.UserId;
            EventId = @event.EventId;
            Event = @event;
        }
        #endregion
    }
}
