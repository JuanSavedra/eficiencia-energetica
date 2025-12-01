using Microsoft.AspNetCore.Mvc;
using eficiência_energética.Attributes;
using eficiência_energética.Interfaces;
using eficiência_energética.ViewModels;

namespace eficiência_energética.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiKey] // Protect all endpoints in this controller
    public class AlertsController : ControllerBase
    {
        private readonly ISensorService _sensorService;

        public AlertsController(ISensorService sensorService)
        {
            _sensorService = sensorService;
        }

        // GET: api/Alerts/active
        [HttpGet("active")]
        public async Task<IActionResult> GetActiveAlerts()
        {
            var alerts = await _sensorService.GetActiveAlertsAsync();
            
            // Mapping to ViewModel (Manual mapping for now, Automapper could be used)
            var result = alerts.Select(a => new AlertViewModel
            {
                Id = a.Id,
                Message = a.Message,
                CreatedAt = a.CreatedAt,
                SensorId = a.SensorId,
                SensorType = a.Sensor?.SensorType ?? "Unknown" 
                // Note: To get SensorType here, we need to ensure the repository includes the navigation property.
                // For this Phase, we accept it might be null/default until eager loading is configured.
            });

            return Ok(result);
        }
    }
}
