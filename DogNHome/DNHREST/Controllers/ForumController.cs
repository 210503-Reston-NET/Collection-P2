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
        public async Task<IActionResult> GetForums()
        {
            return Ok(await _BL.GetAllForums());
        }

        // GET api/<DogController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetForum(int id)
        {
            return Ok(await _BL.GetForum(id));
        }

        // PUT api/<DogController>
        [HttpPost]
        public async Task<IActionResult> AddForum(Forum forum)
        {
            await _BL.AddForum(forum);
            return NoContent();
            /*
             * {
             *  forumID: number,
             *  Topic: string,
             *  description: string
             * }
             */
        }

        // POST api/<DogController>
        [HttpPut]
        public async Task<IActionResult> UpdateForum([FromBody] Forum forum)
        {
            await _BL.UpdateForum(forum);
            return NoContent();
        }

        // DELETE api/<DogController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteForum([FromBody] Forum forum)
        {
            await _BL.RemoveForum(forum);
            return NoContent();
        }
    }
}
