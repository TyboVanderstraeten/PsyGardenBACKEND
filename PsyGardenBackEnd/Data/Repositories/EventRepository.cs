using Microsoft.EntityFrameworkCore;
using PsyGardenBackEnd.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsyGardenBackEnd.Data.Repositories
{
    public class EventRepository : IEventRepository
    {
        #region Properties
        private PsyGardenDBContext _dbContext;
        private DbSet<Event> _events;
        //private DbSet<Location> _locations;
        #endregion

        #region Constructors
        public EventRepository(PsyGardenDBContext dbContext)
        {
            _dbContext = dbContext;
            _events = dbContext.Events;
            //_locations = dbContext.Locations;
        }
        #endregion

        #region Methods
        public IEnumerable<Event> GetAll()
        {
            return _events
                .Include(e => e.Genres)
                .Include(e => e.Prices)
                .Include(e => e.Resources)
                .Include(e => e.Location)
                .ThenInclude(l => l.Country)
                .ToList();
        }

        public Event GetById(int eventId)
        {
            return _events
                .Include(e => e.Genres)
                .Include(e => e.Prices)
                .Include(e => e.Resources)
                .Include(e => e.Location)
                .ThenInclude(l => l.Country)
                .SingleOrDefault(e => e.EventId == eventId);
        }

        public void Add(Event @event)
        {
            _events.Add(@event);
        }

        public void Update(Event @event)
        {
            _events.Update(@event);
        }

        public void Delete(Event @event)
        {
            _events.Remove(@event);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
        #endregion
    }
}
