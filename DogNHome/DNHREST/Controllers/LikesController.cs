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
    public class LikesController : ControllerBase
    {
        private readonly IBussiness _BL;

        public LikesController (IBussiness BL)
        {
            _BL = BL;
        }
        // GET: api/<DogController>
        [HttpGet]
        public async Task<IActionResult> GetAllLikes()
        {
            try
            {
                return Ok(await _BL.GetAllLikes());
            } catch (Exception e)
            {
                Log.Error("Failed to get all Like objects in LikeController", e.Message);
                return NotFound();
            }
        }

        // GET api/<DogController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLike(int Id)
        {
            try
            {
                return Ok(await _BL.GetLike(Id));
            }
            catch (Exception e)
            {
                Log.Error("Failed to get Like object with id: " + Id + " in LikeController", e.Message);
                return NotFound();
            }
        }

        // PUT api/<DogController>
        [HttpPost]
        public async Task<IActionResult> AddLike(Like like)
        {
            try
            {
                await _BL.AddLike(like);
                Task<DogList> result = _BL.GetFavoriteDogsForAsync(like.UserName);

                result.Wait();

                DogList list = result.Result;
               
                await _BL.AddListedDog(new ListedDog(list.ListID + "", like.DogID));
                return NoContent();
            }
            catch (Exception e)
            {
                Log.Error("Failed to Add Like object with userID: " + like.UserName + " in LikeController", e.Message);
                return BadRequest();
            }
        }

        // POST api/<DogController>
        [HttpPut]
        public async Task<IActionResult> UpdateLike([FromBody] Like like)
        {
            try
            {
                await _BL.UpdateLike(like);
                return NoContent();
            }
            catch (Exception e)
            {
                Log.Error("Failed to update Like object with userID: " + like.UserName + " in LikeController", e.Message);
                return BadRequest();
            }
        }

        // DELETE api/<DogController>/5
        [HttpDelete]
        public async Task<IActionResult> DeleteLikes(Like like)
        {
            try
            {
                await _BL.RemoveLike(like);
                return NoContent();
            }
            catch (Exception e)
            {
                Log.Error("Failed to delete Like object with userID: " + like.UserName + " in LikeController", e.Message);
                return BadRequest();
            }
        }
    }
}
