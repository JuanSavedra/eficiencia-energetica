using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eficiência_energética.Models
{
    public class SensorReading
    {
        [Key]
        public int Id { get; set; }

        public double Value { get; set; }

        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        // Foreign Key
        public int SensorId { get; set; }

        [ForeignKey("SensorId")]
        public Sensor? Sensor { get; set; }
    }
}
