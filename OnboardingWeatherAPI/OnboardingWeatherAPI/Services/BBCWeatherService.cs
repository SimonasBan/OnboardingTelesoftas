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
            //city.BBCForecasterData.RssId
            throw new NotImplementedException();
        }
    }
}
