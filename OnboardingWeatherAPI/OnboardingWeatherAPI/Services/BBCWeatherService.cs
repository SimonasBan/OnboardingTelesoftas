using OnboardingWeatherAPI.Models;
using OnboardingWeatherAPI.Models.Shared;

namespace OnboardingWeatherAPI.Services
{
    public class BBCWeatherService : IWeatherForecastService
    {
        private readonly ApplicationDbContext _context;
        public BBCWeatherService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task<double> GetCurrentWeatherByCity(City city)
        {
            ReadXml(city.BbcForecasterData.RssCode);
            //city.BbcForecasterData.RssCode
            throw new NotImplementedException();
        }

        private void ReadXml(string rssCode)
        {
            var bbcUrl = "https://weather-broker-cdn.api.bbci.co.uk/en/forecast/rss/3day/";
            bbcUrl += rssCode;
        }
    }
}
