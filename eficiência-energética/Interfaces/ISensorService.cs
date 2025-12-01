using eficiência_energética.Models;
using eficiência_energética.ViewModels;

namespace eficiência_energética.Interfaces
{
    public interface ISensorService
    {
        Task RecordReadingAsync(int sensorId, double value);
        Task<IEnumerable<Alert>> GetActiveAlertsAsync();
        // Updated to support pagination properly returning PagedResult
        Task<PagedResult<SensorReading>> GetReadingsForSensorPagedAsync(int sensorId, int page, int pageSize);
    }
}