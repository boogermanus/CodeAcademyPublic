using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CS321_W5D2_BlogAPI.ApiModels;
using CS321_W5D2_BlogAPI.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CS321_W5D2_BlogAPI.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _config;

        public AuthController(UserManager<AppUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _config = configuration;
        }

        // POST api/values
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegistrationModel registration)
        {
            // create a new domain user and email, name, etc
            var newUser = new AppUser
            {
                UserName = registration.Email,
                Email = registration.Email,
                FirstName = registration.FirstName,
                LastName = registration.LastName
                // note that we do NOT assign password. Instead of a Password property, there is
                // PaswordHashed, which will be assigned when we create the user. It will store
                // the password in a secure form.
            };
            // use UserMager to create a new User. Pass in the password so it can be hashed.
            var result = await _userManager.CreateAsync(newUser, registration.Password);
            if (result.Succeeded)
            {
                return Ok(newUser.ToApiModel());
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return BadRequest(ModelState);
        }

        // POST api/auth/login
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginModel login)
        {
            IActionResult response = Unauthorized();
            // try to authenticate user
            var user = await AuthenticateUserAsync(login.Email, login.Password);

            // if we successfully authenticated...
            if (user != null)
            {
                // generate and return the token
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString, email = login.Email });
            }

            return response;
        }

        private string GenerateJSONWebToken(AppUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            // retrieve secret key from configuration
            var key = Encoding.ASCII.GetBytes(_config["Jwt:Key"]);
            // create signing credentials using secrety key
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);
            var roles = _userManager.GetRolesAsync(user).Result;
            // set up claims containing additional info that will be stored in token
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email)
             };
            // add role claims
            claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));
            // create the token
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: credentials);
            return tokenHandler.WriteToken(token);
        }

        private async Task<AppUser> AuthenticateUserAsync(string userName, string password)
        {
            // retrieve the user by username and then check password
            var user = await _userManager.FindByNameAsync(userName);
            if (user != null && await _userManager.CheckPasswordAsync(user, password))
            {
                return user;
            }
            return null;
        }
    }
}