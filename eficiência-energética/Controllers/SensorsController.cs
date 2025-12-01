using Microsoft.AspNetCore.Mvc;
using eficiência_energética.Attributes;
using eficiência_energética.Interfaces;
using eficiência_energética.ViewModels;

namespace eficiência_energética.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SensorsController : ControllerBase
    {
        private readonly ISensorService _sensorService;

        public SensorsController(ISensorService sensorService)
        {
            _sensorService = sensorService;
        }

        // POST: api/Sensors/readings
        [HttpPost("readings")]
        [ApiKey] // Protect this endpoint
        public async Task<IActionResult> PostReading([FromBody] ReadingInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _sensorService.RecordReadingAsync(model.SensorId, model.Value);
                return Ok(new { Message = "Reading recorded successfully" });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                // In production, log this exception
                return StatusCode(500, new { Message = "An error occurred while processing the request." });
            }
        }

        // GET: api/Sensors/{id}/readings
        [HttpGet("{id}/readings")]
        public async Task<IActionResult> GetReadings(int id, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            if (page < 1 || pageSize < 1)
            {
                return BadRequest("Page and PageSize must be greater than 0.");
            }

            var result = await _sensorService.GetReadingsForSensorPagedAsync(id, page, pageSize);
            return Ok(result);
        }
    }
}
