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
    public class PreferenceController : ControllerBase
    {
        private readonly IBussiness _BL;

        public PreferenceController (IBussiness BL)
        {
            _BL = BL;
        }
        // GET: api/<DogController>
        [HttpGet]
        public async Task<IActionResult> GetPreferences()
        {
            return Ok(await _BL.GetAllPreferences());
        }

        // GET api/<DogController>/5
        [HttpGet("{userName}")]
        public async Task<IActionResult> GetPreferenceForUser(string userName)
        {
            return Ok(await _BL.GetPreferencesFor(userName));
        }
        // GET api/<DogController>/5
        [HttpGet("{tagID}")]
        public async Task<IActionResult> GetPreferenceForTag(int tagID)
        {
            return Ok(await _BL.GetRelatedPreferences(tagID));
        }

        // PUT api/<DogController>
        [HttpPost]
        public async Task<IActionResult> AddForum(Preference pref)
        {
            await _BL.AddPreference(pref);
            return NoContent();
        }

        // POST api/<DogController>
        [HttpPut]
        public async Task<IActionResult> UpdateForum([FromBody] Preference Pref)
        {
            await _BL.UpdatePreference(Pref);
            return NoContent();
        }

        // DELETE api/<DogController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteForum(Preference pref)
        {
            await _BL.RemovePreference(pref);
            return NoContent();
        }
    }
}
