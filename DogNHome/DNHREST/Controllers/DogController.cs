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
        public async Task<IActionResult> GetDogs()
        {
            return Ok(await _BL.GetAllDogs());
        }

        // GET api/<DogController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDog(int id)
        {
            return Ok(await _BL.GetDogByID(id));
        }

        // PUT api/<DogController>
        [HttpPost]
        public async Task<IActionResult> AddDog(Dog dog)
        {
            await _BL.AddDog(dog);
            return NoContent();
        }

        // POST api/<DogController>
        [HttpPut]
        public async Task<IActionResult> UpdateDog([FromBody] Dog dog)
        {
            await _BL.UpdateDog(dog);
            return NoContent();
        }

        // DELETE api/<DogController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDog(int id)
        {
            await _BL.RemoveDogByID(id);
            return NoContent();
        }
    }
}
