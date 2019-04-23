using System;
using System.Collections.Generic;
using System.Linq;

namespace PsyGardenBackEnd.Models.Domain
{
    public class User
    {
        #region Backingfields
        private string _firstname;
        private string _lastname;
        #endregion

        #region Properties
        public int UserId { get; set; }

        public string FirstName {
            get {
                return _firstname;
            }
            set {
                if (value.Length > 50) {
                    throw new ArgumentException("First name contains 50 char. max");
                }
                else {
                    _firstname = value;
                }
            }
        }

        public string LastName {
            get {
                return _lastname;
            }
            set {
                if (value.Length > 50) {
                    throw new ArgumentException("Last name contains 50 char. max");
                }
                else {
                    _lastname = value;
                }
            }
        }

        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public ICollection<UserInterested> Interests { get; set; }
        public ICollection<UserGoing> Goings { get; set; }
        #endregion

        #region Constructors
        public User()
        {
            Interests = new List<UserInterested>();
            Goings = new List<UserGoing>();
        }

        public User(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            IsAdmin = false;
            Interests = new List<UserInterested>();
            Goings = new List<UserGoing>();
        }
        #endregion

        #region Methods
        public void AddInterested(Event @event)
        {
            if (Interests.Any(ui => ui.EventId == @event.EventId)) {
                throw new Exception("Event already in 'Interested'");
            }
            else if (Goings.Any(ug => ug.EventId == @event.EventId)) {
                UserGoing userGoing = Goings.SingleOrDefault(ug => ug.EventId == @event.EventId);
                Goings.Remove(userGoing);
                UserInterested userInterested = new UserInterested(this, @event);
                Interests.Add(userInterested);
            }
            else {
                UserInterested userInterested = new UserInterested(this, @event);
                Interests.Add(userInterested);
            }
        }

        public void RemoveInterested(Event @event)
        {
            if (!Interests.Any(ui => ui.EventId == @event.EventId)) {
                throw new Exception("Event not in 'Interested'");
            }
            else {
                UserInterested userInterested = Interests.SingleOrDefault(ui => ui.EventId == @event.EventId);
                Interests.Remove(userInterested);
            }
        }

        public void AddGoing(Event @event)
        {
            if (Goings.Any(ug => ug.EventId == @event.EventId)) {
                throw new Exception("Event already in 'Going'");
            }
            else if (Interests.Any(ui => ui.EventId == @event.EventId)) {
                UserInterested userInterested = Interests.SingleOrDefault(ui => ui.EventId == @event.EventId);
                Interests.Remove(userInterested);
                UserGoing userGoing = new UserGoing(this, @event);
                Goings.Add(userGoing);
            }
            else {
                UserGoing userGoing = new UserGoing(this, @event);
                Goings.Add(userGoing);
            }
        }

        public void RemoveGoing(Event @event)
        {
            if (!Goings.Any(ug => ug.EventId == @event.EventId)) {
                throw new Exception("Event not in 'Going'");
            }
            else {
                UserGoing userGoing = Goings.SingleOrDefault(ug => ug.EventId == @event.EventId);
                Goings.Remove(userGoing);
            }
        }
        #endregion
    }
}
