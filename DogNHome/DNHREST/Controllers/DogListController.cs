using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNHBL;
using DNHModels;
using DNHREST.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DNHREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogListController : ControllerBase
    {
        private readonly IBussiness _BL;

        public DogListController (IBussiness BL)
        {
            _BL = BL;
        }
        // GET: api/<DogController>
        [HttpGet]
        public async Task<IActionResult> GetDogLists()
        {
            return Ok(await _BL.GetAllDogLists());
        }


        [HttpPost("{id}")]
        // POST BaseURL/DogList/{listId}
        public async Task<IActionResult> AddDogs(int id, SomeDogs given)
        {
            await _BL.AddsListOfDogs(id, given.dogs);
            return Created("api/DogList",id);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDogList(int id)
        {
            return Ok(await _BL.GetDogListByID(id));
        }

        // PUT api/<DogController>
        [HttpPost]
        public async Task<IActionResult> AddDogList(DogList dogList)
        {
            await _BL.AddNewDogList(dogList);
            return NoContent();
        }

        // POST api/<DogController>
        [HttpPut]
        public async Task<IActionResult> UpdateDogList([FromBody] DogList dogList)
        {
            await _BL.UpdateDogList(dogList);
            return NoContent();
        }

        // DELETE api/<DogController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDogList(int id)
        {
            await _BL.RemoveDogList(id);
            return NoContent();
        }
    }
}
