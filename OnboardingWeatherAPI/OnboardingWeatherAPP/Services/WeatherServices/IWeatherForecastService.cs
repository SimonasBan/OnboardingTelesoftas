using Newtonsoft.Json.Linq;
using OnboardingWeatherAPI.Models;

namespace OnboardingWeatherAPI.Services
{
    public interface IWeatherForecastService
    {
        Task<bool> AddTodaysFactualWeatherForCity(long cityId);
        //string GetCurrentWeatherForCity(/*long cityId*/);
    }
}
