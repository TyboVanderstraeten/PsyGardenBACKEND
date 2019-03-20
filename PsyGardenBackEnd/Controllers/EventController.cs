using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PsyGardenBackEnd.Models.Domain;

namespace PsyGardenBackEnd.Controllers
{
    [Route("PsyGardenAPI/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private IEventRepository _eventRepository;

        public EventController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return _eventRepository.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Event> Get(int id)
        {
            Event @event = _eventRepository.GetById(id);
            if (@event == null) {
                return NotFound();
            }
            else {
                return @event;
            }
        }

        [HttpPost]
        public void Post(Event @event)
        {
            Event temp = new Event();
            temp.EventId = @event.EventId;
            temp.Name = @event.Name;
            temp.Description = @event.Description;
            temp.StartDate = @event.StartDate;
            temp.EndDate = @event.EndDate;
            temp.Location = @event.Location;
            //temp.Genres = @event.Genres;
            temp.Prices = @event.Prices;
            temp.Resources = @event.Resources;
            _eventRepository.Add(temp);
            _eventRepository.SaveChanges();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Event @event = _eventRepository.GetById(id);
            if (@event == null) {
                return NotFound();
            }
            else {
                _eventRepository.Delete(@event);
                _eventRepository.SaveChanges();
                return Ok();
            }
        }
    }
}
