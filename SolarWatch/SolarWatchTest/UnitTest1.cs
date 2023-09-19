using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using SolarWatch.Controllers;

using SolarWatch.Services.JSon;

using SolarWatch.Services;

namespace SolarWatchTest
{
    public class Tests
    {
        private SunriseController _controller;
        private Mock<ILogger<SunriseController>> _loggerMock;
        private Mock<IWeatherDataProvider> _weatherDataProviderMock;
        private Mock<IJsonProcessor> _jsonProcessorMock;

        [SetUp]
        public void Setup()
        {
            _loggerMock = new Mock<ILogger<SunriseController>>();
            _weatherDataProviderMock = new Mock<IWeatherDataProvider>();
            _jsonProcessorMock = new Mock<IJsonProcessor>();
            _controller = new SunriseController(_loggerMock.Object, _weatherDataProviderMock.Object,
                _jsonProcessorMock.Object);
        }

        [Test]

        public async Task GetSunriseSunsetAsync_InvalidCity_ReturnsNotFound()
        {
            // Arrange
            var cityName = "InvalidCity";
            var date = DateTime.Now;

            _weatherDataProviderMock.Setup(w => w.GetLatLon(cityName))
                .Returns(""); // Simulating invalid city response

            // Act
            var result = _controller.GetSunriseSunset(cityName, date);

            // Assert
            Assert.IsInstanceOf<NotFoundObjectResult>(result.Result);
        }
    }
}