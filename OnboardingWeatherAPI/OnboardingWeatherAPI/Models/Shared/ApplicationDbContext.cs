using Microsoft.EntityFrameworkCore;

namespace OnboardingWeatherAPI.Models.Shared
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<City> Cities { get; set; }
        public DbSet<FactualWeatherPrediction> FactualWeatherPredictions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
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