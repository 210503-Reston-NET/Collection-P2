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
    public class ForumController : ControllerBase
    {
        private readonly IBussiness _BL;

        public ForumController (IBussiness BL)
        {
            _BL = BL;
        }
        // GET: api/<DogController>
        [HttpGet]
        public IActionResult GetForums()
        {
            return Ok(_BL.GetAllForums().Result);
        }

        // GET api/<DogController>/5
        [HttpGet("{id}")]
        public IActionResult GetForum(int id)
        {
            return Ok(_BL.GetForum(id).Result);
        }

        // PUT api/<DogController>
        [HttpPost]
        public IActionResult AddForum(Forum forum)
        {
            
            return Created("api/Forum" , _BL.AddForum(forum));
        }

        // POST api/<DogController>
        [HttpPut]
        public IActionResult UpdateForum([FromBody] Forum forum)
        {
            _BL.UpdateForum(forum);
            return NoContent();
        }

        // DELETE api/<DogController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteForum(Forum forum)
        {
            _BL.RemoveForum(forum);
            return NoContent();
        }
    }
}
