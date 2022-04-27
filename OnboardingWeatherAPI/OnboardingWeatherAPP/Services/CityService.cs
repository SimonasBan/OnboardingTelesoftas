using Microsoft.EntityFrameworkCore;
using OnboardingWeatherAPI.Models;
using OnboardingWeatherAPI.Models.Shared;

namespace OnboardingWeather.Aplication.Services
{
    public class CityService
    {
        private readonly ApplicationDbContext _context;
        public CityService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<long>?> GetAllCitiesIds()
        {
            var citiesId = await _context.Cities.Select(e => e.Id).ToListAsync();

            return citiesId;
        }

        
    }
}
