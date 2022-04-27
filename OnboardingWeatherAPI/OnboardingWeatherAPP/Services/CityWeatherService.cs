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



        

        
    }
}
