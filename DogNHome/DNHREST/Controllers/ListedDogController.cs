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
        public IActionResult GetDogLists()
        {
            return Ok(_BL.GetAllListedDogs().Result);
        }

        // GET api/<DogController>/5
        [HttpGet("{id}")]
        public IActionResult GetListedDogForDogID(int dogId)
        {
            return Ok(_BL.GetListedDogsForDog(dogId).Result);
        }
        // GET api/<DogController>/5
        [HttpGet("{id}")]
        public IActionResult GetListedDogForListID(int listId)
        {
            return Ok(_BL.GetListedDogsForList(listId).Result);
        }

        // PUT api/<DogController>
        [HttpPut]
        public IActionResult AddListedDog(ListedDog listedDog)
        {
            _BL.AddListedDog(listedDog);
            return NoContent();
        }

        // POST api/<DogController>
        [HttpPost]
        public IActionResult UpdateListedDog([FromBody] ListedDog dog)
        {
            _BL.UpdateListedDog(dog);
            return NoContent();
        }

        // DELETE api/<DogController>/5
        [HttpDelete]
        public IActionResult DeleteListedDog([FromBody] ListedDog dog)
        {
            _BL.RemoveListedDog(dog);
            return NoContent();
        }
    }
}
