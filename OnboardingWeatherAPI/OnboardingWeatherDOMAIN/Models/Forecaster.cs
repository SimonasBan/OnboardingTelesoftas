using OnboardingWeatherDOMAIN.Models;

namespace OnboardingWeatherAPI.Models
{
    public class Forecaster
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public List<CityForecaster>? CityForecasters { get; set; }

        //public ICollection<FactualWeatherPrediction> FactualWeatherPredictions { get; set; }
    }
}
