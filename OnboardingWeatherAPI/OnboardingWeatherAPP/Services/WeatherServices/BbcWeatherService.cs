using Newtonsoft.Json.Linq;
using OnboardingWeatherAPI.Services;

namespace OnboardingWeather.Aplication.Services
{
    public class BbcWeatherService : IWeatherForecastService
    {
        public string GetCurrentWeatherForCity()
        {
            Console.WriteLine("BbcWeather service action");
            return "BBC";
        }
    }
}
