namespace OnboardingWeatherAPI.Models
{
    public class FactualWeatherPrediction
    {
        public long Id { get; set; }
        public double Temperature { get; set; }
        public DateTime Date { get; set; }
        
        public long CityId { get; set; }
        public City City { get; set; }
        public long ForecasterId { get; set; }
        public Forecaster Forecaster { get; set; }        
    }
}