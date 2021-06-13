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
    public class PostController : ControllerBase
    {
        private readonly IBussiness _BL;

        public PostController (IBussiness BL)
        {
            _BL = BL;
        }
        // GET: api/<DogController>
        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            return Ok(await _BL.GetAllPosts());
        }

        // GET api/<DogController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            return Ok(await _BL.GetPostForForumWithID(id));
        }

        // PUT api/<DogController>
        [HttpPost]
        public async Task<IActionResult> AddPost(Posts post)
        {
            await _BL.AddPost(post);
            return NoContent();
        }

        // POST api/<DogController>
        [HttpPut]
        public async Task<IActionResult> UpdatePost([FromBody] Posts post)
        {
            await _BL.UpdatePost(post);
            return NoContent();
        }

        // DELETE api/<DogController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(Posts post)
        {
            await _BL.RemovePost(post);
            return NoContent();
        }
    }
}
