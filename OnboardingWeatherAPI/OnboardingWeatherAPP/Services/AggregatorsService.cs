using Microsoft.EntityFrameworkCore;
using OnboardingWeatherAPI.Models.Shared;

namespace OnboardingWeather.Aplication.Services
{
    public class AggregatorsService
    {
        private readonly ApplicationDbContext _context;

        public AggregatorsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<TemperatureModel>?> GetTemperatureModelsForCityByDate (long cityId, DateTime fromDate, DateTime toDate)
        {
            var temperatureModels = new List<TemperatureModel>();

            var factualTemperatures = await _context.FactualPredictions
                .Where(e => e.CityId == cityId 
                && e.Date >= fromDate && e.Date <= toDate)
                .ToListAsync();


            foreach (DateTime day in EachDay(fromDate, toDate))
            {
                var dayTemperatures = new List<double>();

                foreach (var concretePrediction in factualTemperatures)
                {
                    if (concretePrediction?.Date == day)
                    {
                        dayTemperatures.Add(concretePrediction.Temperature);
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
