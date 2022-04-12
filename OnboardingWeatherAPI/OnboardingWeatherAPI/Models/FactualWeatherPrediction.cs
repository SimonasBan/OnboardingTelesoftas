namespace OnboardingWeatherAPI.Models
{
    public class FactualWeatherPrediction
    {
        public long Id { get; set; }
        public double Temperature { get; set; }
        public DateTime Date { get; set; }

        public City City { get; set; }
        public Forecaster Forecaster { get; set; }
    }
}

/*FactualWeather - non changing
 * ->City
 * DateTime date
 * float temp
 * enum resource
 */