using System.Collections.Specialized;
using SolarWatch.Models.Data;

namespace SolarWatch.Services.JSon
{
    public interface IJsonProcessor
    {
        GeocordingApiResponse GetCeoGeocordingApiResponse(string data);
        SunriseSunsetResult Process(string data, string city, DateTime date);

    }
}
