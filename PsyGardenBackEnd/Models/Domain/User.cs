using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsyGardenBackEnd.Models.Domain
{
    public class User
    {
        #region Properties
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public ICollection<UserInterested> Interests { get; set; }
        public ICollection<UserGoing> Goings { get; set; }
        public IEnumerable<Event> EventsInterestedIn => Interests.Select(i => i.Event);
        public IEnumerable<Event> EventsGoingTo => Goings.Select(i => i.Event);
        #endregion

        #region Constructors
        public User()
        {
            Interests = new List<UserInterested>();
            Goings = new List<UserGoing>();
        }
        #endregion

        #region Methods
        public void AddInterested(Event @event)
        {
            UserInterested userInterested = new UserInterested(this, @event);
            Interests.Add(userInterested);
        }

        public void RemoveInterested(Event @event)
        {
            UserInterested userInterested = Interests.SingleOrDefault(ui => ui.EventId == @event.EventId);
            Interests.Remove(userInterested);
        }

        public void AddGoing(Event @event)
        {
            UserGoing userGoing = new UserGoing(this, @event);
            Goings.Add(userGoing);
        }

        public void RemoveGoing(Event @event)
        {
            UserGoing userGoing = Goings.SingleOrDefault(ug => ug.EventId == @event.EventId);
            Goings.Remove(userGoing);
        }
        #endregion
    }
}
