namespace SolarWatch.Models.Data
{
    public class SunriseSunsetResult
    {
        public string City { get; set; }
        public DateTime? Date { get; set; }
        public DateTimeOffset Sunrise { get; set; }
        public DateTimeOffset Sunset { get; set; }
    }
}
