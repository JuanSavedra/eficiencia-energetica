using Microsoft.EntityFrameworkCore;
using eficiência_energética.Data;
using eficiência_energética.Interfaces;
using eficiência_energética.Models;
using eficiência_energética.ViewModels;

namespace eficiência_energética.Services
{
    public class SensorService : ISensorService
    {
        private readonly IRepository<Sensor> _sensorRepository;
        private readonly IRepository<SensorReading> _readingRepository;
        private readonly IRepository<Alert> _alertRepository;
        private readonly ApplicationDbContext _context; // Needed for queryable access

        public SensorService(
            IRepository<Sensor> sensorRepository,
            IRepository<SensorReading> readingRepository,
            IRepository<Alert> alertRepository,
            ApplicationDbContext context)
        {
            _sensorRepository = sensorRepository;
            _readingRepository = readingRepository;
            _alertRepository = alertRepository;
            _context = context;
        }

        public async Task RecordReadingAsync(int sensorId, double value)
        {
            var sensor = await _sensorRepository.GetByIdAsync(sensorId);
            if (sensor == null)
            {
                throw new KeyNotFoundException($"Sensor with ID {sensorId} not found.");
            }

            var reading = new SensorReading
            {
                SensorId = sensorId,
                Value = value,
                Timestamp = DateTime.UtcNow
            };
            await _readingRepository.AddAsync(reading);

            if (value > sensor.AlertThreshold)
            {
                var alert = new Alert
                {
                    SensorId = sensorId,
                    Message = $"Alert: Sensor '{sensor.SensorType}' exceeded threshold. Value: {value}, Threshold: {sensor.AlertThreshold}",
                    CreatedAt = DateTime.UtcNow,
                    IsResolved = false
                };
                await _alertRepository.AddAsync(alert);
            }
        }

        public async Task<IEnumerable<Alert>> GetActiveAlertsAsync()
        {
            // Basic implementation for now. Pagination can be added here too if needed.
            return await _alertRepository.FindAsync(a => !a.IsResolved);
        }

        public async Task<PagedResult<SensorReading>> GetReadingsForSensorPagedAsync(int sensorId, int page, int pageSize)
        {
            var query = _context.SensorReadings.Where(r => r.SensorId == sensorId);

            var totalCount = await query.CountAsync();
            var items = await query
                .OrderByDescending(r => r.Timestamp)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<SensorReading>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = page,
                PageSize = pageSize
            };
        }

        // Keep the old method for interface compatibility if needed, or remove it if interface is updated.
        // For this refactor, we will update the interface.
        public Task<IEnumerable<SensorReading>> GetReadingsForSensorAsync(int sensorId, int limit = 100)
        {
             throw new NotImplementedException("Use Paged version instead.");
        }
    }
}