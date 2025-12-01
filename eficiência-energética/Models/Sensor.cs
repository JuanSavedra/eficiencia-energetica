using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eficiência_energética.Models
{
    public class Sensor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string SensorType { get; set; } = string.Empty; // e.g., "PowerUsage", "Temperature"

        public double AlertThreshold { get; set; } // Value that triggers an alert

        // Foreign Key
        public int EquipmentId { get; set; }
        
        [ForeignKey("EquipmentId")]
        public Equipment? Equipment { get; set; }

        // Navigation properties
        public ICollection<SensorReading> Readings { get; set; } = new List<SensorReading>();
        public ICollection<Alert> Alerts { get; set; } = new List<Alert>();
    }
}
