using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMDBapp.Services;
using IMDBapp.Models;
using IMDBapp.Models.Request;
using IMDBapp.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IMDBapp.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<ActorController>
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
            var users = _userService.Get();
            return Ok(users);
        }

        // GET api/<ActorController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var users = _userService.Get(id);
            
            if (users == null)
            {
                return NotFound("No record found!");
            }
            else
            {
                return Ok(users);
            }
        }

        [HttpPost]
        [Route("signup")]
        public IActionResult Signup([FromBody] User user)
        {
            _userService.Signup(user);
            return Ok(new { data = "User created successfully!" });
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] User user)
        {
            return Ok(new { data = _userService.Login(user) });
        }


        // POST api/<UserController>
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            _userService.Post(user);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<ActorController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _userService.Put(id, user);
            return Ok("Record updated!");
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userService.Delete(id);
            return Ok("Record deleted!");
        }
    }
}
