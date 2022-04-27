using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using OnboardingWeatherAPI.Models;
using OnboardingWeatherAPI.Models.Shared;
using OnboardingWeatherAPI.Services;

namespace OnboardingWeather.Aplication.Services
{
    public class BbcWeatherService : IWeatherForecastService
    {
        private readonly ApplicationDbContext _context;
        public BbcWeatherService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddTodaysFactualWeatherForCity(long cityId)
        {
            var city = await _context.Cities
                .Include(e => e.CityForecasters)
                .Where(x => x.Id == cityId)
                .FirstOrDefaultAsync();

            Console.WriteLine("BbcWeather service action");
            return false;
        }

        //public async Task<List<FactualWeatherPrediction>?> GetFactualTemperaturesForCityByDate(long cityId, DateTime fromDate, DateTime toDate)
        //{
        //    return await _context.FactualPredictions
        //        .Include(e => e.Forecaster)
        //        .Where(e => e.CityId == cityId && e.Forecaster.Name == "BBC"
        //        && e.Date >= fromDate && e.Date <= toDate)
        //        .ToListAsync();
        //}
    }
}
