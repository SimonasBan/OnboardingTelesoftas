using Microsoft.EntityFrameworkCore;
using OnboardingWeatherAPI.Models;
using OnboardingWeatherAPI.Models.Shared;

namespace OnboardingWeatherAPI.Services
{
    public class CityWeatherService
    {
        private readonly ApplicationDbContext _context;
        public CityWeatherService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<string>?> GetAvailableCitiesNames()
        {
            var availableCitiesNames = new List<string>();

            availableCitiesNames = await _context.Cities.Select(e => e.Name).ToListAsync();

            return availableCitiesNames;
        }

        public List<TemperatureModel> GetAverageTemperaturesFromFactualForecasts(List<List<FactualWeatherPrediction?>> factualPredictions, DateTime fromDate, DateTime toDate)
        {
            var temperatureModels = new List<TemperatureModel>();

            foreach (DateTime day in EachDay(fromDate, toDate))
            {
                var dayTemperatures = new List<double>();

                foreach (var predictionList in factualPredictions)
                {
                    foreach (var concretePrediction in predictionList)
                    {
                        if (concretePrediction?.Date == day)
                        {
                            dayTemperatures.Add(concretePrediction.Temperature);
                        }
                    }
                }

                if (dayTemperatures.Count > 0)
                {
                    temperatureModels.Add(new TemperatureModel
                    {
                        Temperature = dayTemperatures.Average(),
                        Date = day
                    });
                }
            }

            return temperatureModels;
        }


        public IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }

        public class TemperatureModel
        {
            public double Temperature { get; set; }
            public DateTime Date { get; set; }
        }
    }
}
