using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsyGardenBackEnd.Models.Domain
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetAll();
        Event GetById(int eventId);
        void Add(Event @event);
        void Update(Event @event);
        void Delete(Event @event);
        void SaveChanges();
    }
}
