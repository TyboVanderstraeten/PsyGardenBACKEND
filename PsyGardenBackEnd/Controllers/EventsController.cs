using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PsyGardenBackEnd.DTO;
using PsyGardenBackEnd.Models.Domain;

namespace PsyGardenBackEnd.Controllers
{
    [Route("PsyGardenAPI/[controller]")]
    [Produces("application/json")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
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
        //[AllowAnonymous]
        [ProducesResponseType(typeof(IEnumerable<Event>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<Event>> GetEvents()
        {
            IEnumerable<Event> events = _eventRepository.GetAll().OrderBy(e => e.StartDate).ToList();
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
        public ActionResult<Event> PostEvent(EventDTO eventDTO)
        {
            try {
                Event eventToCreate = new Event() {
                    Name = eventDTO.Name,
                    Description = eventDTO.Description,
                    StartDate = eventDTO.StartDate,
                    EndDate = eventDTO.EndDate,
                    Country = eventDTO.Country,
                    Region = eventDTO.Region,
                    City = eventDTO.City,
                    Street = eventDTO.Street,
                    StreetNr = eventDTO.StreetNr,
                    ZipCode = eventDTO.ZipCode,
                    HeaderImageURL = eventDTO.HeaderImageURL
                };

                foreach (var genre in eventDTO.EventGenres) {
                    Genre genreToAdd = _genreRepository.GetById(genre.GenreId);
                    eventToCreate.AddEventGenre(genreToAdd);
                }

                foreach (var price in eventDTO.Prices) {
                    eventToCreate.AddPrice(new Price() { Name = price.Name, Description = price.Description, Cost = price.Cost });
                }

                foreach (var resource in eventDTO.Links) {
                    eventToCreate.AddLink(new Link() { Name = resource.Name, Url = resource.Url });
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
        public ActionResult PutEvent(int id, EventDTO eventDTO)
        {
            Event eventToEdit = _eventRepository.GetById(id);
            if (eventToEdit == null) {
                return NotFound();
            }
            else {
                eventToEdit.Name = eventDTO.Name;
                eventToEdit.Description = eventDTO.Description;
                eventToEdit.StartDate = eventDTO.StartDate;
                eventToEdit.EndDate = eventDTO.EndDate;
                eventToEdit.Country = eventDTO.Country;
                eventToEdit.Region = eventDTO.Region;
                eventToEdit.City = eventDTO.City;
                eventToEdit.Street = eventDTO.Street;
                eventToEdit.StreetNr = eventDTO.StreetNr;
                eventToEdit.ZipCode = eventDTO.ZipCode;
                eventToEdit.HeaderImageURL = eventDTO.HeaderImageURL;

                foreach (var eventGenre in eventToEdit.EventGenres) {
                    Genre genreToRemove = eventGenre.Genre;
                    eventToEdit.RemoveEventGenre(genreToRemove);
                    EventGenreDTO eventGenreFromDTO = eventDTO.EventGenres.SingleOrDefault(eg => eg.GenreId == eventGenre.GenreId);
                    Genre genreToAdd = _genreRepository.GetById(eventGenreFromDTO.GenreId);
                    eventToEdit.AddEventGenre(genreToAdd);
                }

                foreach (var price in eventToEdit.Prices) {
                    PriceDTO priceFromDTO = eventDTO.Prices.SingleOrDefault(p => p.PriceId == price.PriceId);
                    price.Name = priceFromDTO.Name;
                    price.Description = priceFromDTO.Description;
                    price.Cost = priceFromDTO.Cost;
                }

                foreach (var link in @eventToEdit.Links) {
                    LinkDTO linkFromDTO = eventDTO.Links.SingleOrDefault(l => l.LinkId == link.LinkId);
                    link.Name = linkFromDTO.Name;
                    link.Url = linkFromDTO.Url;
                }

                _eventRepository.Update(eventToEdit);
                _eventRepository.SaveChanges();
                return Ok();
            }
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
                return Ok(@event);
            }
        }
    }
}
