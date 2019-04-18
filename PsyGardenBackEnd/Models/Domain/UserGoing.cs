using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsyGardenBackEnd.Models.Domain
{
    public class UserGoing
    {
        #region Properties
        public int UserId { get; set; }
        public int EventId { get; set; }
        public User User { get; set; }
        public Event Event { get; set; }
        #endregion

        #region Constructors
        public UserGoing()
        {

        }

        public UserGoing(User user, Event @event)
        {
            UserId = user.UserId;
            EventId = @event.EventId;
            User = user;
            Event = @event;
        }
        #endregion
    }
}
