namespace eficiência_energética.ViewModels
{
    public class AlertViewModel
    {
        public int Id { get; set; }
        public string Message { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public int SensorId { get; set; }
        public string SensorType { get; set; } = string.Empty;
    }
}
