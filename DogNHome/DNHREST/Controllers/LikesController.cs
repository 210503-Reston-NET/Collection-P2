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
    public class LikesController : ControllerBase
    {
        private readonly IBussiness _BL;

        public LikesController (IBussiness BL)
        {
            _BL = BL;
        }
        // GET: api/<DogController>
        [HttpGet]
        public IActionResult GetAllLikes()
        {
            return Ok(_BL.GetAllLikes().Result);
        }

        // GET api/<DogController>/5
        [HttpGet("{id}")]
        public IActionResult GetLike(int Id)
        {
            return Ok(_BL.GetLike(Id).Result);
        }

        // PUT api/<DogController>
        [HttpPut]
        public IActionResult AddLike(Like like)
        {
            _BL.AddLike(like);
            return NoContent();
        }

        // POST api/<DogController>
        [HttpPost]
        public IActionResult UpdateLike([FromBody] Like like)
        {
            _BL.UpdateLike(like);
            return NoContent();
        }

        // DELETE api/<DogController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteForum(Like like)
        {
            _BL.RemoveLike(like);
            return NoContent();
        }
    }
}
