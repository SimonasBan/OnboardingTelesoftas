using OnboardingWeatherAPI.Models;

namespace OnboardingWeatherAPI.Services
{
    public interface IWeatherForecastService
    {
        Task<double> GetCurrentWeatherByCity(City city);
    }
}
