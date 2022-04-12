namespace OnboardingWeatherAPI.Models
{
    public class Forecaster
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public ICollection<FactualWeatherPrediction> FactualWeatherPredictions { get; set; }
    }
}
