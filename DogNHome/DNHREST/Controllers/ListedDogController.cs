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
    public class ListedDogController : ControllerBase
    {
        private readonly IBussiness _BL;

        public ListedDogController (IBussiness BL)
        {
            _BL = BL;
        }
        // GET: api/<DogController>
        [HttpGet]
        public async Task<IActionResult> GetDogLists()
        {
            try
            {
                return Ok(await _BL.GetAllListedDogs());
            } catch (Exception e)
            {
                Log.Error("Failed to get all DogList in DogListController", e.Message);
                return NotFound();
            }
        }

        // GET api/<DogController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetListedDogForDogID(string id)
        {
            try
            {
                return Ok(await _BL.GetListedDogsForDog(id));
            }
            catch (Exception e)
            {
                Log.Error("Failed to get DogList with id: " + id + " in DogListController", e.Message);
                return NotFound();
            }
        }

        // PUT api/<DogController>
        [HttpPost]
        public async Task<IActionResult> AddListedDog(ListedDog listedDog)
        {
            try
            {
                await _BL.AddListedDog(listedDog);
                return Created("api/ListedDog", listedDog.ListID);
            }
            catch (Exception e)
            {
                Log.Error("Failed to add DogList with Dogid: " + listedDog.APIID + " in DogListController", e.Message);
                return BadRequest();
            }
        }

        // POST api/<DogController>
        [HttpPut]
        public async Task<IActionResult> UpdateListedDog([FromBody] ListedDog dog)
        {
            try
            {
                await _BL.UpdateListedDog(dog);
                return NoContent();
            }
            catch (Exception e)
            {
                Log.Error("Failed to update DogList with Dogid: " + dog.APIID + " in DogListController", e.Message);
                return BadRequest();
            }
        }

        // DELETE api/<DogController>/5
        [HttpDelete]
        public async Task<IActionResult> DeleteListedDog([FromBody] ListedDog dog)
        {
            try
            {
                await _BL.RemoveListedDog(dog);
                return NoContent();
            }
            catch (Exception e)
            {
                Log.Error("Failed to Delete DogList with Dogid: " + dog.APIID + " in DogListController", e.Message);
                return BadRequest();
            }
        }
    }
}
