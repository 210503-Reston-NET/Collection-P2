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
    public class CommentController : ControllerBase
    {
        private readonly IBussiness _BL;

        public CommentController (IBussiness BL)
        {
            _BL = BL;
        }
        // GET: api/<DogController>
        [HttpGet]
        public async Task<IActionResult> GetAllComments()
        {
            return Ok(await _BL.GetAllComments());
        }

        // GET api/<DogController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetComment(int id)
        {
            return Ok(await _BL.GetComment(id));
        }

        // PUT api/<DogController>
        [HttpPost]
        public async Task<IActionResult> AddForum(Comments comm)
        {
            await _BL.AddComment(comm);
            return NoContent();
        }

        // POST api/<DogController>
        [HttpPut]
        public async Task<IActionResult> UpdateComment([FromBody] Comments comm)
        {
            await _BL.UpdateComment(comm);
            return NoContent();
        }

        // DELETE api/<DogController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(Comments comm)
        {
            await _BL.RemoveComments(comm);
            return NoContent();
        }
    }
}
