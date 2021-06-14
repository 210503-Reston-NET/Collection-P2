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
            return Ok(await _BL.GetAllListedDogs());
        }

        // GET api/<DogController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetListedDogForDogID(string id)
        {
            return Ok(await _BL.GetListedDogsForDog(id));
        }
        /*
        // GET api/<DogController>/5
        [HttpGet("{id}")]
        public IActionResult GetListedDogForListID(int listId)
        {
            return Ok(_BL.GetListedDogsForList(listId).Result);
        }
        */

        // PUT api/<DogController>
        [HttpPost]
        public async Task<IActionResult> AddListedDog(ListedDog listedDog)
        {
            await _BL.AddListedDog(listedDog);
            return Created("api/ListedDog" ,await _BL.AddListedDog(listedDog));
        }

        // POST api/<DogController>
        [HttpPut]
        public async Task<IActionResult> UpdateListedDog([FromBody] ListedDog dog)
        {
            await _BL.UpdateListedDog(dog);
            return NoContent();
        }

        // DELETE api/<DogController>/5
        [HttpDelete]
        public async Task<IActionResult> DeleteListedDog([FromBody] ListedDog dog)
        {
            await _BL.RemoveListedDog(dog);
            return NoContent();
        }
    }
}
