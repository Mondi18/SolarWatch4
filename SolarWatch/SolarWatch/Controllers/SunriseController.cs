using Microsoft.AspNetCore.Mvc;
using SolarWatch.Models.Data;
using SolarWatch.Services;
using SolarWatch.Services.JSon;

namespace SolarWatch.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SunriseController : Controller
    {
        private readonly ILogger<SunriseController> _logger;
        private readonly HttpClient _httpClient;
        private readonly IWeatherDataProvider _weatherDataProvider;
        private readonly IJsonProcessor _jsonProcessor;
        public SunriseController(ILogger<SunriseController> logger, IWeatherDataProvider weatherDataProvider,
            IJsonProcessor jsonProcessor)
        {
            _logger = logger;
            _weatherDataProvider = weatherDataProvider;
            _jsonProcessor = jsonProcessor;
            _httpClient = new HttpClient();
        }
        [HttpGet]
        [Route("api/solar")]
        public ActionResult<SunriseSunsetResult> GetSunriseSunset(string city, DateTime date)
        {
            try
            {
                var GeoData = _weatherDataProvider.GetLatLon(city);
                var GeoResult = _jsonProcessor.GetCeoGeocordingApiResponse(GeoData);

                var lat = GeoResult.Coord.Lat;
                var lon = GeoResult.Coord.Lon;

                var weatherData = _weatherDataProvider.GetSunriseSunset(lat, lon, date);

                return Ok(_jsonProcessor.Process(weatherData, city, date));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error getting weather data");
                return NotFound("Error getting weather data");
            }
        }
    }
}

