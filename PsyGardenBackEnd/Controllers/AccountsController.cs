using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PsyGardenBackEnd.DTO;
using PsyGardenBackEnd.Models.Domain;

namespace PsyGardenBackEnd.Controllers
{
    [Route("PsyGardenAPI/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private SignInManager<IdentityUser> _signInManager;
        private UserManager<IdentityUser> _userManager;
        private IUserRepository _userRepository;
        private IConfiguration _configuration;

        public AccountsController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager,
            IUserRepository userRepository, IConfiguration configuration)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _userRepository = userRepository;
            _configuration = configuration;
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="loginDTO">The login details</param>
        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<String>> CreateToken(LoginDTO loginDTO)
        {
            var user = await _userManager.FindByNameAsync(loginDTO.Email);
            if (user != null) {
                var result = await _signInManager.CheckPasswordSignInAsync(user, loginDTO.Password, false);
                if (result.Succeeded) {
                    string token = GetToken(user);
                    return Created("", token);
                }
            }
            return BadRequest();
        }

        /// <summary>
        /// Register
        /// </summary>
        /// <param name="registerDTO">The register details</param>
        [AllowAnonymous]
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<String>> Register(RegisterDTO registerDTO)
        {
            IdentityUser identityUser = new IdentityUser() { UserName = registerDTO.Email, Email = registerDTO.Email };
            User user = new User() { FirstName = registerDTO.FirstName, LastName = registerDTO.LastName, Email = registerDTO.Email };
            var result = await _userManager.CreateAsync(identityUser, registerDTO.Password);

            if (result.Succeeded) {
                _userRepository.Add(user);
                _userRepository.SaveChanges();
                string token = GetToken(identityUser);
                return Created("", token);
            }
            return BadRequest();
        }

        private String GetToken(IdentityUser user)
        {
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub,user.Email),
                new Claim(JwtRegisteredClaimNames.UniqueName,user.UserName)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                null, null, claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}