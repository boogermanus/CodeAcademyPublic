using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CS321_W5D1_ExerciseLogAPI.ApiModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using CS321_W5D1_ExerciseLogAPI.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CS321_W5D1_ExerciseLogAPI.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        // TODO: Prep Part 2: inject IConfiguration in the constructor

        // TODO: Prep Part 1: Add a Registration Action (Part 1 of Prep exercise)
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationModel model)
        {
            var newUser = new User
            {
                UserName = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(newUser, model.Password);

            if (result.Succeeded)
                return Ok(newUser.ToApiModel());

            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);

            return BadRequest(ModelState);
        }
        

        // TODO: Prep Part 2: Add a login action (Part 2 of Prep exercise)

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            IActionResult response = Unauthorized();

            var user = await AuthenticateUserAsync(model.Email, model.Password);

            if (user != null)
            {
                var token = GenerateJsonWebToken(user);
                response = Ok(new {token});
            }

            return response;
        }

        private async Task<User> AuthenticateUserAsync(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);

            if (user != null && await _userManager.CheckPasswordAsync(user, password))
            {
                return user;
            }

            return null;
        }

        private string GenerateJsonWebToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            // this will error out at first because we haven't completed the work. comment it out
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);
            var roles = _userManager.GetRolesAsync(user).Result;

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email)
            };
            claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: credentials);

            return tokenHandler.WriteToken(token);
        }
    }
}
