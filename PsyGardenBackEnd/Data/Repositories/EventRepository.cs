﻿using Microsoft.EntityFrameworkCore;
using PsyGardenBackEnd.Models.Domain;
using System.Collections.Generic;
using System.Linq;

namespace PsyGardenBackEnd.Data.Repositories
{
    public class EventRepository : IEventRepository
    {
        #region Properties
        private PsyGardenDBContext _dbContext;
        private DbSet<Event> _events;
        #endregion

        #region Constructors
        public EventRepository(PsyGardenDBContext dbContext)
        {
            _dbContext = dbContext;
            _events = dbContext.Events;
        }
        #endregion

        #region Methods
        public IEnumerable<Event> GetAll()
        {
            return _events
                .Include(e => e.EventGenres).ThenInclude(eg => eg.Genre)
                .Include(e => e.Prices)
                .Include(e => e.Links)
                .ToList();
        }

        public Event GetById(int eventId)
        {
            return _events
                .Include(e => e.EventGenres).ThenInclude(eg => eg.Genre)
                .Include(e => e.Prices)
                .Include(e => e.Links)
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
