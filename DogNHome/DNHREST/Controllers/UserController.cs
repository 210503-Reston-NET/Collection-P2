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
            return Ok(await _BL.GetAllUsers());
        }

        // GET api/<DogController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            return Ok(await _BL.GetUser(id));
        }

        // PUT api/<DogController>
        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            await _BL.AddUser(user);
            return NoContent();
        }

        // POST api/<DogController>
        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
        {
            await _BL.UpdateUser(user);
            return NoContent();
        }

        // DELETE api/<DogController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            await _BL.RemoveUser(id);
            return NoContent();
        }
    }
}
