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
        public IActionResult GetAllComments()
        {
            return Ok(_BL.GetAllComments().Result);
        }

        // GET api/<DogController>/5
        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
            return Ok(_BL.GetComment(id).Result);
        }

        // PUT api/<DogController>
        [HttpPut]
        public IActionResult AddForum(Comments comm)
        {
            _BL.AddComment(comm);
            return NoContent();
        }

        // POST api/<DogController>
        [HttpPost]
        public IActionResult UpdateComment([FromBody] Comments comm)
        {
            _BL.UpdateComment(comm);
            return NoContent();
        }

        // DELETE api/<DogController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteComment(Comments comm)
        {
            _BL.RemoveComments(comm);
            return NoContent();
        }
    }
}
