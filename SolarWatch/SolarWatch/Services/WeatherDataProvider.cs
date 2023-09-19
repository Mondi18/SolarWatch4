using System.Net;

namespace SolarWatch.Services
{
    public class WeatherDataProvider : IWeatherDataProvider
    {
        private readonly ILogger<WeatherDataProvider> _logger;
        private readonly string apiKey = "ae9e787ec8dcbd2e38562d1a038d7cc5";
        public WeatherDataProvider(ILogger<WeatherDataProvider> logger)
        {
            _logger = logger;
        }
        public string GetLatLon(string city)
        {

            var geoUrl = $"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}";
            var client = new WebClient();

            _logger.LogInformation("Calling OpenWeather API with url: {url}", geoUrl);
            return client.DownloadString(geoUrl);
        }

      

        public string GetSunriseSunset(double lat, double lon, DateTime date)
        {
            var sunriseSunsetUrl = $"https://api.sunrise-sunset.org/json?lat={lat}&lng={lon}&date={date:yyyy-MM-dd}&formatted=0";
            var client = new WebClient();

            _logger.LogInformation("Calling OpenWeather API with url: {url}", sunriseSunsetUrl);
            return client.DownloadString(sunriseSunsetUrl);
        }
    }
}
