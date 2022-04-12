using Microsoft.EntityFrameworkCore;
using OnboardingWeatherAPI.Models.Configurations;

namespace OnboardingWeatherAPI.Models.Shared
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<City> Cities { get; set; }
        public DbSet<FactualWeatherPrediction> FactualWeatherPredictions { get; set; }
        public DbSet<Forecaster> Forecasters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new FactualWeatherPredictionConfiguration());
            modelBuilder.Seed();
        }
    }

    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var kaunas = new City
            {
                Id = 1,
                Name = "Kaunas"
            };

            var vilnius = new City
            {
                Id = 2,
                Name = "Vilnius"
            };

            var klaipeda = new City
            {
                Id = 3,
                Name = "Klaipėda"
            };

            modelBuilder.Entity<City>().HasData(
                kaunas,
                vilnius,
                klaipeda
            );

            var openWeather = new Forecaster
            {
                Id = 1,
                Name = "OpenWeatherMap"
            };

            modelBuilder.Entity<Forecaster>().HasData(
                openWeather
            );

            //modelBuilder.Entity<FactualWeatherPrediction>().HasData(
            //    new FactualWeatherPrediction
            //    {
            //        Id = 1,
            //        Date = DateTime.Now,
            //        Temperature = 12.5,
            //        City = kaunas,
            //        Forecaster = openWeather
            //    },
            //    new FactualWeatherPrediction
            //    {
            //        Id = 2,
            //        Date = DateTime.Now.AddDays(-1),
            //        Temperature = 11.2,
            //        City = kaunas,
            //        Forecaster = openWeather
            //    },
            //    new FactualWeatherPrediction
            //    {
            //        Id = 2,
            //        Date = DateTime.Now,
            //        Temperature = 10.2,
            //        City = vilnius,
            //        Forecaster = openWeather
            //    }
            //);
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