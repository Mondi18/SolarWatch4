using SolarWatch.Models.Data;
using System.Text.Json;

namespace SolarWatch.Services.JSon
{
    public class JsonProcessor : IJsonProcessor
    {
        public GeocordingApiResponse GetCeoGeocordingApiResponse(string data)
        {
            JsonDocument json = JsonDocument.Parse(data);
            JsonElement coord = json.RootElement.GetProperty("coord");

            Coordinates Coordinates = new Coordinates
            {
                Lat = coord.GetProperty("lat").GetDouble(),
                Lon = coord.GetProperty("lon").GetDouble()
            };

            GeocordingApiResponse response = new GeocordingApiResponse()
            {
                Coord = Coordinates
            };

            return response;
        }
        public SunriseSunsetResult Process(string data, string city, DateTime date)
        {
            JsonDocument json = JsonDocument.Parse(data);
            JsonElement res = json.RootElement.GetProperty("results");

            SunriseSunsetResult latAndLon = new SunriseSunsetResult
            {
                City = city,
                Date = date,
                Sunrise = res.GetProperty("sunrise").GetDateTimeOffset().ToLocalTime(),
                Sunset = res.GetProperty("sunset").GetDateTimeOffset().ToLocalTime(),
            };

            return latAndLon;
        }
    }
}
