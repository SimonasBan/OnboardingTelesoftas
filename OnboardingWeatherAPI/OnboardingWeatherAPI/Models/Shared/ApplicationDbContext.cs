using System.Data.Entity;

namespace OnboardingWeatherAPI.Models.Shared
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<City> City { get; set; }
    }
}

//City->has many CityWeather
//City->has many FactualWeather

/*City:
 * 
 * */

//PredictedWeather:
//fecthDate



/*FactualWeather - non changing
 * ->City
 * DateTime date
 * float temp
 * enum resource
 */