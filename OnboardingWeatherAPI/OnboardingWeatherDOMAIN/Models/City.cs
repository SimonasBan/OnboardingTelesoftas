namespace OnboardingWeatherAPI.Models
{
    public class City
    {
        public City()
        {
            //FactualWeatherPredictions = new HashSet<FactualWeatherPrediction>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public ICollection<FactualWeatherPrediction> FactualWeatherPredictions { get; set; }
    }
}
