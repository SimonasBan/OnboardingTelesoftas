using Newtonsoft.Json.Linq;
using OnboardingWeatherAPI.Models;

namespace OnboardingWeatherAPI.Services
{
    public interface IWeatherForecastService
    {
        //Task<JObject?> GetCurrentWeatherForCity(/*long cityId*/);
        string GetCurrentWeatherForCity(/*long cityId*/);
    }
}
