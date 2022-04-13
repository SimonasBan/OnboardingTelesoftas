using OnboardingWeatherAPI.Models;

namespace OnboardingWeatherAPI.Services
{
    public interface IWeatherForecastService
    {
        double GetCurrentWeatherByCity(City city);
    }
}
