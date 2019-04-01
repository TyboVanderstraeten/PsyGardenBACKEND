﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PsyGardenBackEnd.Models.Domain;

namespace PsyGardenBackEnd.Controllers
{
    [Route("PsyGardenAPI/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private IEventRepository _eventRepository;

        public EventsController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Event> PostEvent(Event @event)
        {
            try {
                _eventRepository.Add(@event);
                _eventRepository.SaveChanges();
                return CreatedAtAction(nameof(GetEvent), new { id = @event.EventId }, @event);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult PutEvent(int id, Event @event)
        {
            if (id != @event.EventId) {
                return BadRequest();
            }
            else {
                _eventRepository.Update(@event);
                _eventRepository.SaveChanges();
                return Ok();
            }
        }

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
    }
}
