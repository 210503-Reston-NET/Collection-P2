using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNHBL;
using DNHModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DNHREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IBussiness _BL;

        public UserController (IBussiness BL)
        {
            _BL = BL;
        }
        // GET: api/<DogController>
        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_BL.GetAllUsers().Result);
        }

        // GET api/<DogController>/5
        [HttpGet("{id}")]
        public IActionResult GetUser(string id)
        {
            return Ok(_BL.GetUser(id).Result);
        }

        // PUT api/<DogController>
        [HttpPut]
        public IActionResult AddUser(User user)
        {
            _BL.AddUser(user);
            return NoContent();
        }

        // POST api/<DogController>
        [HttpPost]
        public IActionResult UpdateUser([FromBody] User user)
        {
            _BL.UpdateUser(user);
            return NoContent();
        }

        // DELETE api/<DogController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(string id)
        {
            _BL.RemoveUser(id);
            return NoContent();
        }
    }
}
