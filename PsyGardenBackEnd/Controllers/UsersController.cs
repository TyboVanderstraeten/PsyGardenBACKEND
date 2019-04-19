using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PsyGardenBackEnd.Models.Domain;
using System.Collections.Generic;
using System.Linq;

namespace PsyGardenBackEnd.Controllers
{
    [Route("PsyGardenAPI/[controller]")]
    [Produces("application/json")]
    [ApiController]
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
        /// <returns>The user</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult DeleteUser()
        {
            User user = _userRepository.GetByEmail(User.Identity.Name);
            if (user == null) {
                return NoContent();
            }
            else {
                _userRepository.Delete(user);
                _userRepository.SaveChanges();
                return Ok(user);
            }
        }

        /////<summary>
        ///// Add event to interested
        /////</summary>
        /////<param name="email">The email of the user</param>
        /////<param name="eventId">The id of the event to be added to interested</param>
        //[HttpPost("{email}/interested")]
        //public IActionResult PostEventToInterested(string email, int eventId)
        //{
        //    try {
        //        Event eventToAdd = _eventRepository.GetById(eventId);

        //    }
        //}

    }
}
