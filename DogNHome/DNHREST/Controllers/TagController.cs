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
    public class TagController : ControllerBase
    {
        private readonly IBussiness _BL;

        public TagController (IBussiness BL)
        {
            _BL = BL;
        }
        // GET: api/<DogController>
        [HttpGet]
        public IActionResult GetTags()
        {
            return Ok(_BL.GetAllTags().Result);
        }

        // GET api/<DogController>/5
        [HttpGet("{id}")]
        public IActionResult GetTag(int id)
        {
            return Ok(_BL.GetTag(id).Result);
        }

        // PUT api/<DogController>
        [HttpPut]
        public IActionResult AddTag(Tags tag)
        {
            _BL.AddTag(tag);
            return NoContent();
        }

        // POST api/<DogController>
        [HttpPost]
        public IActionResult UpdateTag([FromBody] Tags tag)
        {
            _BL.UpdateTag(tag);
            return NoContent();
        }

        // DELETE api/<DogController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteTag(Tags tag)
        {
            _BL.RemoveTag(tag);
            return NoContent();
        }
    }
}
