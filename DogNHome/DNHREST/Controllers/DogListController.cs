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
    public class DogListController : ControllerBase
    {
        private readonly IBussiness _BL;

        public DogListController (IBussiness BL)
        {
            _BL = BL;
        }
        // GET: api/<DogController>
        [HttpGet]
        public IActionResult GetDogLists()
        {
            return Ok(_BL.GetAllDogLists());
        }

        // GET api/<DogController>/5
        [HttpGet("{id}")]
        public IActionResult GetDogList(int id)
        {
            return Ok(_BL.GetDogListByID(id));
        }

        // PUT api/<DogController>
        [HttpPut]
        public IActionResult AddDogList(DogList dogList)
        {
            _BL.AddNewDogList(dogList);
            return NoContent();
        }

        // POST api/<DogController>
        [HttpPost]
        public IActionResult UpdateDogList([FromBody] DogList dogList)
        {
            _BL.UpdateDogList(dogList);
            return NoContent();
        }

        // DELETE api/<DogController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteDogList(int id)
        {
            _BL.RemoveDogList(id);
            return NoContent();
        }
    }
}
