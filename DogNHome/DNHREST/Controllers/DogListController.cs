using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNHBL;
using DNHModels;
using DNHREST.DTO;
using Serilog;

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
            try
            {
                return Ok(await _BL.GetAllDogLists());
            } catch(Exception e)
            {
                Log.Error("Failed to get all DogLists in DogListController", e.Message);
                return NotFound();
            }
        }


        [HttpPost("{id}")]
        // POST BaseURL/DogList/{listId}
        public async Task<IActionResult> AddDogs(int id, SomeDogs given)
        {
            try
            {
                await _BL.AddsListOfDogs(id, given.dogs);
                return Created("api/DogList", id);
            }
            catch (Exception e)
            {
                Log.Error("Failed to add DogList with ListID " + id + " with multiple dogs in DogListController", e.Message);
                return BadRequest();
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDogList(string id)
        {
            try
            {
                return Ok(await _BL.GetDogListsFor(id));
            }
            catch (Exception e)
            {
                Log.Error("Failed to get DogList with ListID " + id + " in DogListController", e.Message);
                return BadRequest();
            }
        }

        // PUT api/<DogController>
        [HttpPost]
        public async Task<IActionResult> AddDogList(DogList dogList)
        {
            try
            {
                return Created("api/DogList", await _BL.AddNewDogList(dogList));
            }
            catch (Exception e)
            {
                Log.Error("Failed to get DogList with ListID " + dogList.ListID + " in DogListController", e.Message);
                return BadRequest();
            }

        }

        // POST api/<DogController>
        [HttpPut]
        public async Task<IActionResult> UpdateDogList([FromBody] DogList dogList)
        {
            try
            {
                await _BL.UpdateDogList(dogList);
                return NoContent();
            }
            catch (Exception e)
            {
                Log.Error("Failed to update DogList with ListID " + dogList.ListID + " in DogListController", e.Message);
                return BadRequest();
            }
        }

        // DELETE api/<DogController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDogList(int id)
        {
            try
            {
                await _BL.RemoveDogList(id);
                return NoContent();
            }
            catch (Exception e)
            {
                Log.Error("Failed to remove DogList with ListID " + id + " in DogListController", e.Message);
                return BadRequest();
            }
        }
    }
}
