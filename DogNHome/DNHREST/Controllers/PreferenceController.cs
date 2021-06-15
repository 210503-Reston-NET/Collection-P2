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
            try
            {
                return Ok(await _BL.GetAllPreferences());
            } catch (Exception e)
            {
                Log.Error("Failed to get all Preferences in PreferenceController", e.Message);
                return NotFound();
            }
        }

        // GET api/<DogController>/5
        [HttpGet("{userName}")]
        public async Task<IActionResult> GetPreferenceForUser(string userName)
        {
            try
            {
                return Ok(await _BL.GetPreferencesFor(userName));
            }
            catch (Exception e)
            {
                Log.Error("Failed to get Preferences with userID: " + userName + " in PreferenceController", e.Message);
                return NotFound();
            }
        }
        // GET api/<DogController>/5
        [HttpGet("{tagID}")]
        public async Task<IActionResult> GetPreferenceForTag(int tagID)
        {
            try
            {
                return Ok(await _BL.GetRelatedPreferences(tagID));
            }
            catch (Exception e)
            {
                Log.Error("Failed to get Preferences with tagID: " + tagID + " in PreferenceController", e.Message);
                return NotFound();
            }
        }

        // PUT api/<DogController>
        [HttpPost]
        public async Task<IActionResult> AddPreference(Preference pref)
        {

            try
            {
                await _BL.AddPreference(pref);
                return NoContent();
            }
            catch (Exception e)
            {
                Log.Error("Failed to add Preferences with tagID: " + pref.TagID + " in PreferenceController", e.Message);
                return BadRequest();
            }
        }

        // POST api/<DogController>
        [HttpPut]
        public async Task<IActionResult> UpdatePreference([FromBody] Preference Pref)
        {
            try
            {
                await _BL.UpdatePreference(Pref);
                return NoContent();
            }
            catch (Exception e)
            {
                Log.Error("Failed to add Preferences with tagID: " + Pref.TagID + " in PreferenceController", e.Message);
                return BadRequest();
            }
        }

        // DELETE api/<DogController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePreference(Preference pref)
        {
            try
            {
                await _BL.RemovePreference(pref);
                return NoContent();
            }
            catch (Exception e)
            {
                Log.Error("Failed to delete Preferences with tagID: " + pref.TagID + " in PreferenceController", e.Message);
                return BadRequest();
            }
        }
    }
}
