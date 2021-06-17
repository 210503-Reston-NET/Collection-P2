using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNHBL;
using DNHModels;
using Serilog;

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
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                return Ok(await _BL.GetAllUsers());
            } catch (Exception e)
            {
                Log.Error("Failed to Get all users in UserController", e.Message);
                return NotFound();
            }
        }

        // GET api/<DogController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            try
            {
                return Ok(await _BL.GetUser(id));
            }
            catch (Exception e)
            {
                Log.Error("Failed to Get user with userID: " + id + " in UserController", e.Message);
                return NotFound();
            }
        }

        // PUT api/<DogController>
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody]string uid)
        {
            try
            {
                return Created("api/User", await _BL.AddUser(uid));
            }
            catch (Exception e)
            {
                Log.Error("Failed to add user with userID: " + uid + " in UserController", e.Message);
                return BadRequest(e.Message);
            }
        }

        // POST api/<DogController>
        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
        {
            try
            {
                await _BL.UpdateUser(user);
                return NoContent();
            }
            catch (Exception e)
            {
                Log.Error("Failed to update user with userID: " + user.UserID + " in UserController", e.Message);
                return BadRequest();
            }
        }

        // DELETE api/<DogController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            try
            {
                await _BL.RemoveUser(id);
                return NoContent();
            }
            catch (Exception e)
            {
                Log.Error("Failed to remove user with userID: " + id + " in UserController", e.Message);
                return BadRequest();
            }
        }
    }
}
