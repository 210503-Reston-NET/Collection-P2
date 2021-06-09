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
        public IActionResult GetPreferences()
        {
            return Ok(_BL.GetAllPreferences().Result);
        }

        // GET api/<DogController>/5
        [HttpGet("{userName}")]
        public IActionResult GetPreferenceForUser(string userName)
        {
            return Ok(_BL.GetPreferencesFor(userName).Result);
        }
        // GET api/<DogController>/5
        [HttpGet("{tagID}")]
        public IActionResult GetPreferenceForTag(int tagID)
        {
            return Ok(_BL.GetRelatedPreferences(tagID).Result);
        }

        // PUT api/<DogController>
        [HttpPut]
        public IActionResult AddForum(Preference pref)
        {
            _BL.AddPreference(pref);
            return NoContent();
        }

        // POST api/<DogController>
        [HttpPost]
        public IActionResult UpdateForum([FromBody] Preference Pref)
        {
            _BL.UpdatePreference(Pref);
            return NoContent();
        }

        // DELETE api/<DogController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteForum(Preference pref)
        {
            _BL.RemovePreference(pref);
            return NoContent();
        }
    }
}
