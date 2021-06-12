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
        public async Task<IActionResult> GetAllLikes()
        {
            return Ok(await _BL.GetAllLikes());
        }

        // GET api/<DogController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLike(int Id)
        {
            return Ok(await _BL.GetLike(Id));
        }

        // PUT api/<DogController>
        [HttpPost]
        public async Task<IActionResult> AddLike(Like like)
        {
            await _BL.AddLike(like);
            return NoContent();
        }

        // POST api/<DogController>
        [HttpPut]
        public async Task<IActionResult> UpdateLike([FromBody] Like like)
        {
            await _BL.UpdateLike(like);
            return NoContent();
        }

        // DELETE api/<DogController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteForum(Like like)
        {
            await _BL.RemoveLike(like);
            return NoContent();
        }
    }
}
