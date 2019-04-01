using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PsyGardenBackEnd.DTO;
using PsyGardenBackEnd.Models.Domain;

namespace PsyGardenBackEnd.Controllers
{
    [Route("PsyGardenAPI/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EventsController : ControllerBase
    {
        private IEventRepository _eventRepository;
        private IGenreRepository _genreRepository;

        public EventsController(IEventRepository eventRepository, IGenreRepository genreRepository)
        {
            _eventRepository = eventRepository;
            _genreRepository = genreRepository;
        }

        /// <summary>
        /// Get all events
        /// </summary>
        /// <returns>All events</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Event>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<Event>> GetEvents()
        {
            IEnumerable<Event> events = _eventRepository.GetAll().OrderBy(e => e.Name).ToList();
            if (events == null) {
                return NotFound();
            }
            else {
                return Ok(events);
            }
        }

        /// <summary>
        /// Get the event with given id
        /// </summary>
        /// <param name="id">The id of the event</param>
        /// <returns>The event</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Event), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Event> GetEvent(int id)
        {
            Event @event = _eventRepository.GetById(id);
            if (@event == null) {
                return NotFound();
            }
            else {
                return Ok(@event);
            }
        }

        /// <summary>
        /// Create the event
        /// </summary>
        /// <param name="event">The event to be created</param>
        /// <returns>The event</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Event> PostEvent(EventDTO @event)
        {
            try {
                Event eventToCreate = new Event() {
                    Name = @event.Name,
                    Description = @event.Description,
                    StartDate = @event.StartDate,
                    EndDate = @event.EndDate,
                    Country = @event.Country,
                    Region = @event.Region,
                    City = @event.City,
                    Street = @event.Street,
                    StreetNr = @event.StreetNr,
                    ZipCode = @event.ZipCode
                };
                foreach (var genre in @event.EventGenres) {
                    Genre genreToAdd = _genreRepository.GetById(genre.GenreId);
                    eventToCreate.AddEventGenre(genreToAdd);
                }
                foreach (var price in @event.Prices) {
                    eventToCreate.AddPrice(new Price() { Name = price.Name, Description = price.Description, Cost = price.Cost });
                }
                foreach (var resource in @event.Resources) {
                    if (resource.Alt == null) {
                        eventToCreate.AddResource(new Link() { Name = resource.Name, Url = resource.Url });
                    }
                    else {
                        eventToCreate.AddResource(new Image() { Name = resource.Name, Url = resource.Url, Alt = resource.Alt });
                    }
                }
                _eventRepository.Add(eventToCreate);
                _eventRepository.SaveChanges();
                return CreatedAtAction(nameof(GetEvent), new { id = eventToCreate.EventId }, eventToCreate);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Edit the event with given id
        /// </summary>
        /// <param name="id">The id of the event</param>
        /// <param name="event">The event to be edited</param>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult PutEvent(int id, EventDTO @event)
        {
            Event eventToEdit = _eventRepository.GetById(id);
            if (eventToEdit == null) {
                return NotFound();
            }
            else {
                MapEventDTOToEvent(@event, eventToEdit);
                _eventRepository.Update(eventToEdit);
                _eventRepository.SaveChanges();
                return Ok();
            }
        }

        /// <summary>
        /// Partially edit the event with given id
        /// </summary>
        /// <param name="id">The id of the event</param>
        /// <param name="event">The event to be partially edited</param>
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult PatchEvent(int id, EventDTO @event)
        {
            return NotFound();
        }

        /// <summary>
        /// Delete the event with given id
        /// </summary>
        /// <param name="id">The id of the event</param>
        /// <returns>The event</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult DeleteEvent(int id)
        {
            Event @event = _eventRepository.GetById(id);
            if (@event == null) {
                return NoContent();
            }
            else {
                _eventRepository.Delete(@event);
                _eventRepository.SaveChanges();
                return Ok();
            }
        }

        private void MapEventDTOToEvent(EventDTO eventDTO, Event @event)
        {
            @event.Name = eventDTO.Name;
            @event.Description = eventDTO.Description;
            @event.StartDate = eventDTO.StartDate;
            @event.EndDate = eventDTO.EndDate;
            @event.Country = eventDTO.Country;
            @event.Region = eventDTO.Region;
            @event.City = eventDTO.City;
            @event.Street = eventDTO.Street;
            @event.StreetNr = eventDTO.StreetNr;
            @event.ZipCode = eventDTO.ZipCode;
            foreach (var price in @event.Prices) {
                //price.Name=
            }
        }
    }
}
