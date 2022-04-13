using Microsoft.EntityFrameworkCore;
using OnboardingWeatherAPI.Models.Configurations;
using OnboardingWeatherDOMAIN.Models;

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
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.Seed();
        }
    }

    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //City seed
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

            var tbilisi = new City
            {
                Id = 4,
                Name = "Tbilisi"
            };

            modelBuilder.Entity<City>().HasData(
                kaunas,
                vilnius,
                klaipeda,
                tbilisi
            );
            //Forecaster seed
            var openWeather = new Forecaster
            {
                Id = 1,
                Name = "OpenWeatherMap"
            };

            modelBuilder.Entity<Forecaster>().HasData(
                openWeather
            );
            //FactualWeatherPrediction seed
            modelBuilder.Entity<FactualWeatherPrediction>().HasData(
                new FactualWeatherPrediction
                {
                    Id = 1,
                    Date = DateTime.Now,
                    Temperature = 12.5,
                    CityId = 1,
                    ForecasterId = 1
                },
                new FactualWeatherPrediction
                {
                    Id = 2,
                    Date = DateTime.Now.AddDays(-1),
                    Temperature = 11.2,
                    CityId = 1,
                    ForecasterId = 1
                },
                new FactualWeatherPrediction
                {
                    Id = 3,
                    Date = DateTime.Now,
                    Temperature = 10.2,
                    CityId = 2,
                    ForecasterId = 1
                }
            );
            //BbcForecastData seed
            modelBuilder.Entity<BbcForecasterData>().HasData(
                new BbcForecasterData
                {
                    Id = 1,
                    RssCode = 611717,
                    CityId = 4
                }
            );
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