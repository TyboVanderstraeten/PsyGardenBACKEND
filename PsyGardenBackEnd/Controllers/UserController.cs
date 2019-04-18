using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PsyGardenBackEnd.Models.Domain;

namespace PsyGardenBackEnd.Controllers
{
    [Route("PsyGardenAPI/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Get the user with given email
        /// </summary>
        /// <returns>The user</returns>
        [HttpGet]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<User> GetUser()
        {
            User user = _userRepository.GetByEmail(User.Identity.Name); 
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

    }
}
