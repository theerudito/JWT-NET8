using JWT_Backend.Context;
using JWT_Backend.Helpers;
using JWT_Models.Dtos;
using JWT_Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWT_Backend.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController(IConfiguration config, Application_ContextDB _db) : Controller
    {
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            var query = _db.Users.ToList();
            return query != null ? Ok(query) : BadRequest(query);
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] AuthDto authDto)
        {
            var newUsers = new Auth
            {
                Email = authDto.Email,
                Password = authDto.Password
            };

            _db.Users.Add(newUsers);
            _db.SaveChanges();

            return Ok(new { message = TokenManager.GenerateToken(authDto, config) });
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register([FromBody] AuthDto authDto)
        {
            var query = _db.Users.FirstOrDefault(x => x.Email == authDto.Email);

            if (query != null)
            {
                return BadRequest(new { message = "Email already exists" });
            } 

            return Ok(new { message = TokenManager.GenerateToken(authDto, config) });
        }
    }
}