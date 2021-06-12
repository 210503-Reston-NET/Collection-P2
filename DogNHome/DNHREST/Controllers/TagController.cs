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
        public async Task<IActionResult> GetTags()
        {
            return Ok(await _BL.GetAllTags());
        }

        // GET api/<DogController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTag(int id)
        {
            return Ok(await _BL.GetTag(id));
        }

        // PUT api/<DogController>
        [HttpPost]
        public async Task<IActionResult> AddTag(Tags tag)
        {
            await _BL.AddTag(tag);
            return NoContent();
        }

        // POST api/<DogController>
        [HttpPut]
        public async Task<IActionResult> UpdateTag([FromBody] Tags tag)
        {
            await _BL.UpdateTag(tag);
            return NoContent();
        }

        // DELETE api/<DogController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTag(Tags tag)
        {
            await _BL.RemoveTag(tag);
            return NoContent();
        }
    }
}
