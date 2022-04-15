using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
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
            //var city = await _context.Cities
            //    .Include(e => e.CityForecasters)
            //    .Where(x => x.Id == cityId)
            //    .FirstOrDefaultAsync();

            Console.WriteLine("BbcWeather service action");
            return false;
        }
    }
}
