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
    public class AlertController : ControllerBase
    {
        IBussiness _BL;
        public AlertController(IBussiness BL)
        {
            _BL = BL;
        }
        // GET: api/<AlertController>
        [HttpGet]
        public async Task<IActionResult> GetAllAlerts()
        {
            try
            {
                return Ok(await _BL.GetAllAlerts());
            }
            catch (Exception e)
            {
                Log.Error("Failed to fullfil request to get all Alerts In Alert Controller", e.Message);
                return NotFound();
            }
        }

        // GET api/<AlertController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlert(string id)
        {
            try
            {
                return Ok(await _BL.GetAlertsForUser(id));
            } catch (Exception e)
            {
                Log.Error("Failed to fullfil request to get Alert for user with ID " + id + " In Alert Controller", e.Message);
                return NotFound();
            }
           
        }

        // POST api/<AlertController>
        [HttpPost]
        public async Task<IActionResult> AddAlert([FromBody] Alert alert)
        {
            try
            {
                return Created("api/Alert", await _BL.AddAlert(alert));
            }
            catch (Exception e)
            {
                Log.Error("Failed to fullfil request to get Alert for user with ID " + id + " In Alert Controller", e.Message);
                return BadRequest();
            }
        }

        // PUT api/<AlertController>/5
        [HttpPut()]
        public async Task<IActionResult> updateAlert([FromBody] Alert alert)
        {
            try
            {
                await _BL.UpdateAlert(alert);
                return NoContent();
            }
            catch (Exception e)
            {
                Log.Error("Failed to fullfil request to update Alert for user with ID " + alert.AlertID + " In Alert Controller", e.Message);
                return BadRequest();
            }
        }

        // DELETE api/<AlertController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlert([FromBody] Alert alert)
        {
            try
            {
                await _BL.RemoveAlert(alert);
                return NoContent();
            }
            catch (Exception e)
            {
                Log.Error("Failed to fullfil request to Remove Alert for user with ID " + alert.AlertID + " In Alert Controller", e.Message);
                return BadRequest();
            }
        }
    }
}
