using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PsyGardenBackEnd.Data;
using PsyGardenBackEnd.Models.Domain;

namespace PsyGardenBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IEventRepository _eventRepository;

        public ValuesController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            IEnumerable<Event> events = _eventRepository.GetAll();
            return events;
        }

        // GET api/values/5
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

        // POST api/values
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

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
