using Newtonsoft.Json.Linq;
using OnboardingWeatherAPI.Models;

namespace OnboardingWeatherAPI.Services
{
    public interface IWeatherForecastService
    {
        Task<bool> AddTodaysFactualWeatherForCity(long cityId);
        Task<List<FactualWeatherPrediction>?> GetfactualTemperaturesForCityByDate(long cityId /*dates*/);
        //string GetCurrentWeatherForCity(/*long cityId*/);
    }
}
