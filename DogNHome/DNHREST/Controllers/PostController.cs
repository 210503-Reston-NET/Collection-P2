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
        public IActionResult GetPosts()
        {
            return Ok(_BL.GetAllPosts().Result);
        }

        // GET api/<DogController>/5
        [HttpGet("{id}")]
        public IActionResult GetPost(int id)
        {
            return Ok(_BL.GetPostForForumWithID(id).Result);
        }

        // PUT api/<DogController>
        [HttpPut]
        public IActionResult AddPost(Posts post)
        {
            _BL.AddPost(post);
            return NoContent();
        }

        // POST api/<DogController>
        [HttpPost]
        public IActionResult UpdatePost([FromBody] Posts post)
        {
            _BL.UpdatePost(post);
            return NoContent();
        }

        // DELETE api/<DogController>/5
        [HttpDelete("{id}")]
        public IActionResult DeletePost(Posts post)
        {
            _BL.RemovePost(post);
            return NoContent();
        }
    }
}
