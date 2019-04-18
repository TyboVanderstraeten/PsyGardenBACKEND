using System.Collections.Generic;

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
