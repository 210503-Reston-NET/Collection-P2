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
    public class DogController : ControllerBase
    {
        private readonly IBussiness _BL;

        public DogController (IBussiness BL)
        {
            _BL = BL;
        }
        // GET: api/<DogController>
        [HttpGet]
        public IActionResult GetDogs()
        {
            return Ok(_BL.GetAllDogs().Result);
        }

        // GET api/<DogController>/5
        [HttpGet("{id}")]
        public IActionResult GetDog(int id)
        {
            Task<Dog> dog = _BL.GetDogByID(id);
            return Ok(dog.Result);
        }

        // PUT api/<DogController>
        [HttpPut]
        public IActionResult AddDog(Dog dog)
        {
            _BL.AddDog(dog);
            return NoContent();
        }

        // POST api/<DogController>
        [HttpPost]
        public IActionResult UpdateDog([FromBody] Dog dog)
        {
            _BL.UpdateDog(dog);
            return NoContent();
        }

        // DELETE api/<DogController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteDog(int id)
        {
            _BL.RemoveDogByID(id);
            return NoContent();
        }
    }
}
