namespace OnboardingWeatherAPI.Models
{
    public class Forecaster
    {
        public Forecaster()
        {
            //FactualWeatherPredictions = new HashSet<FactualWeatherPrediction>();
        }
        public long Id { get; set; }
        public string Name { get; set; }

        public ICollection<FactualWeatherPrediction> FactualWeatherPredictions { get; set; }
    }
}
