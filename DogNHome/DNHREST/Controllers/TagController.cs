using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNHBL;
using DNHModels;
using Serilog;

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
            try
            {
                return Ok(await _BL.GetAllTags());
            } catch(Exception e)
            {
                Log.Error("Failed to return all tags in TagController", e.Message);
                return NotFound();
            }
        }

        // GET api/<DogController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTag(int id)
        {
            try
            {
                return Ok(await _BL.GetTag(id));
            }
            catch (Exception e)
            {
                Log.Error("Failed to return tag with ID: " + id + " in TagController", e.Message);
                return NotFound();
            }
        }

        // PUT api/<DogController>
        [HttpPost]
        public async Task<IActionResult> AddTag(Tags tag)
        {
            try
            {
                await _BL.AddTag(tag);
                return NoContent();
            }
            catch (Exception e)
            {
                Log.Error("Failed to add tag with ID: " + tag.TagID + " in TagController", e.Message);
                return NotFound();
            }
        }

        // POST api/<DogController>
        [HttpPut]
        public async Task<IActionResult> UpdateTag([FromBody] Tags tag)
        {
            try
            {
                await _BL.UpdateTag(tag);
                return NoContent();
            }
            catch (Exception e)
            {
                Log.Error("Failed to update tag with ID: " + tag.TagID + " in TagController", e.Message);
                return NotFound();
            }
        }

        // DELETE api/<DogController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTag(Tags tag)
        {
            try
            {
                await _BL.RemoveTag(tag);
                return NoContent();
            }
            catch (Exception e)
            {
                Log.Error("Failed to Delete tag with ID: " + tag.TagID + " in TagController", e.Message);
                return NotFound();
            }
        }
    }
}
