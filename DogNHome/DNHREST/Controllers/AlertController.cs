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
    public class AlertController : ControllerBase
    {
        IBussiness _BL;
        public AlertController(IBussiness BL)
        {
            _BL = BL;
        }
        // GET: api/<AlertController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AlertController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlert(string id)
        {
            return Ok(await _BL.GetAlertsForUser(id));
        }

        // POST api/<AlertController>
        [HttpPost]
        public async Task<IActionResult> AddAlert([FromBody] Alert alert)
        {
            return Created("api/Alert", await _BL.AddAlert(alert));
        }

        // PUT api/<AlertController>/5
        [HttpPut()]
        public async Task<IActionResult> updateAlert([FromBody] Alert alert)
        {
            await _BL.UpdateAlert(alert);
            return NoContent();
        }

        // DELETE api/<AlertController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlert([FromBody] Alert alert)
        {
            await _BL.RemoveAlert(alert);
            return NoContent();
        }
    }
}
