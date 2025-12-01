using System.ComponentModel.DataAnnotations;

namespace eficiência_energética.Models
{
    public class Equipment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(50)]
        public string Type { get; set; } = string.Empty; // e.g., "HVAC", "Server", "Lighting"

        [MaxLength(100)]
        public string Location { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        // Navigation property
        public ICollection<Sensor> Sensors { get; set; } = new List<Sensor>();
    }
}
