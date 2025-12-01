using System.ComponentModel.DataAnnotations;

namespace eficiência_energética.ViewModels
{
    public class ReadingInputModel
    {
        [Required]
        public int SensorId { get; set; }

        [Required]
        public double Value { get; set; }
    }
}
