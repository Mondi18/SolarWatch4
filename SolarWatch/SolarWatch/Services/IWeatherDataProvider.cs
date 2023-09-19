namespace SolarWatch.Services
{
    public interface IWeatherDataProvider
    {
        string GetLatLon(string city);
        string GetSunriseSunset (double lat, double lon,DateTime Date);
    }
}
