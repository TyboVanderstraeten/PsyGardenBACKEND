using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PsyGardenBackEnd.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsyGardenBackEnd.Controllers
{
    [Route("PsyGardenAPI/[controller]")]
    [Produces("application/json")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UsersController : ControllerBase
    {
        private IUserRepository _userRepository;
        private IEventRepository _eventRepository;

        public UsersController(IUserRepository userRepository, IEventRepository eventRepository)
        {
            _userRepository = userRepository;
            _eventRepository = eventRepository;
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns>All users</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<User>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            IEnumerable<User> users = _userRepository.GetAll().OrderBy(u => u.LastName).ThenBy(u => u.FirstName).ToList();
            if (users == null) {
                return NotFound();
            }
            else {
                return Ok(users);
            }
        }

        /// <summary>
        /// Get the user with given email
        /// </summary>
        /// <param name="email">The email of the user</param>
        /// <returns>The user</returns>
        [HttpGet("{email}")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<User> GetUser(string email)
        {
            User user = _userRepository.GetByEmail(email);
            if (user == null) {
                return NotFound();
            }
            else {
                return Ok(user);
            }
        }

        /// <summary>
        /// Delete the user with given email
        /// </summary>
        /// <param name="email">The email of the user</param>
        /// <returns>The user</returns>
        [HttpDelete("{email}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult DeleteUser(string email)
        {
            User user = _userRepository.GetByEmail(email);
            if (user == null) {
                return NoContent();
            }
            else {
                _userRepository.Delete(user);
                _userRepository.SaveChanges();
                return Ok(user);
            }
        }

        ///<summary>
        /// Add event to interested
        ///</summary>
        ///<param name="email">The email of the user</param>
        ///<param name="eventId">The id of the event to be added to interested</param>        
        /// <returns>The user</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("interested/{email}")]
        public IActionResult PostEventToInterested(string email, int eventId)
        {
            try {
                Event eventToAddToInterested = _eventRepository.GetById(eventId);
                User user = _userRepository.GetByEmail(email);
                if (eventToAddToInterested == null || user == null) {
                    return NotFound();
                }
                else {
                    user.AddInterested(eventToAddToInterested);
                    _userRepository.SaveChanges();
                    return Ok(user);
                }
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        ///<summary>
        /// Add event to going
        ///</summary>
        ///<param name="email">The email of the user</param>
        ///<param name="eventId">The id of the event to be added to going</param>
        /// <returns>The user</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("going/{email}")]
        public IActionResult PostEventToGoing(string email, int eventId)
        {
            try {
                Event eventToAddToGoing = _eventRepository.GetById(eventId);
                User user = _userRepository.GetByEmail(email);
                if (eventToAddToGoing == null || user == null) {
                    return NotFound();
                }
                else {
                    user.AddGoing(eventToAddToGoing);
                    _userRepository.SaveChanges();
                    return Ok(user);
                }
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        ///<summary>
        /// Delete event from interested
        ///</summary>
        ///<param name="email">The email of the user</param>
        ///<param name="eventId">The id of the event to be deleted from interested</param>
        /// <returns>The user</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("interested/{email}")]
        public IActionResult DeleteEventFromInterested(string email, int eventId)
        {
            try {
                Event eventToDeleteFromInterested = _eventRepository.GetById(eventId);
                User user = _userRepository.GetByEmail(email);
                if (eventToDeleteFromInterested == null || user == null) {
                    return NoContent();
                }
                else {
                    user.RemoveInterested(eventToDeleteFromInterested);
                    _userRepository.SaveChanges();
                    return Ok(user);
                }
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        ///<summary>
        /// Delete event from going
        ///</summary>
        ///<param name="email">The email of the user</param>
        ///<param name="eventId">The id of the event to be deleted from going</param>
        /// <returns>The user</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("going/{email}")]
        public IActionResult DeleteEventFromGoing(string email, int eventId)
        {
            try {
                Event eventToDeleteFromInterested = _eventRepository.GetById(eventId);
                User user = _userRepository.GetByEmail(email);
                if (eventToDeleteFromInterested == null || user == null) {
                    return NoContent();
                }
                else {
                    user.RemoveGoing(eventToDeleteFromInterested);
                    _userRepository.SaveChanges();
                    return Ok(user);
                }
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}
