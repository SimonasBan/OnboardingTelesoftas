using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnboardingWeatherAPI.Models.Configurations;
using OnboardingWeatherDOMAIN.Models;
//using OnboardingWeatherDOMAIN.Models;

namespace OnboardingWeatherAPI.Models.Shared
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<City> Cities { get; set; }
        public DbSet<Forecaster> Forecasters { get; set; }
        public DbSet<CityForecaster> CityForecasters { get; set; }
        public DbSet<FactualWeatherPrediction> FactualPredictions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //--------
            modelBuilder.Entity<CityForecaster>()
            .HasKey(t => new { t.CityId, t.ForecasterId });

            modelBuilder.Entity<CityForecaster>()
                .HasOne(pt => pt.City)
                .WithMany(p => p.CityForecasters)
                .HasForeignKey(pt => pt.CityId);

            modelBuilder.Entity<CityForecaster>()
                .HasOne(pt => pt.Forecaster)
                .WithMany(t => t.CityForecasters)
                .HasForeignKey(pt => pt.ForecasterId);
            //--------
            modelBuilder.Entity<FactualWeatherPrediction>()
                .HasOne(e => e.City)
                .WithMany(e => e.FactualPredictions)
                .HasForeignKey(e => e.CityId);

            modelBuilder.Entity<FactualWeatherPrediction>()
                .HasOne(e => e.Forecaster)
                .WithMany(e => e.FactualPredictions)
                .HasForeignKey(e => e.ForecasterId);
        }
    }

    //public static class ModelBuilderExtensions
    //{
    //    public static void Seed(this ModelBuilder modelBuilder)
    //    {
    //        //BbcForecastData seed
    //        modelBuilder.Entity<BbcForecasterData>().HasData(
    //            new BbcForecasterData
    //            {
    //                Id = 1,
    //                RssCode = "611717"
    //            }
    //        );
    //        //City seed
    //        var kaunas = new City
    //        {
    //            Id = 1,
    //            Name = "Kaunas",
    //        };

    //        var vilnius = new City
    //        {
    //            Id = 2,
    //            Name = "Vilnius"
    //        };

    //        var klaipeda = new City
    //        {
    //            Id = 3,
    //            Name = "Klaipėda"
    //        };

    //        var tbilisi = new City
    //        {
    //            Id = 4,
    //            Name = "Tbilisi",
    //            BbcForecasterDataId = 1
    //        };

    //        modelBuilder.Entity<City>().HasData(
    //            kaunas,
    //            vilnius,
    //            klaipeda,
    //            tbilisi
    //        );
    //        //Forecaster seed
    //        var openWeather = new Forecaster
    //        {
    //            Id = 1,
    //            Name = "OpenWeatherMap"
    //        };

    //        modelBuilder.Entity<Forecaster>().HasData(
    //            openWeather
    //        );
    //        //FactualWeatherPrediction seed
    //        modelBuilder.Entity<FactualWeatherPrediction>().HasData(
    //            new FactualWeatherPrediction
    //            {
    //                Id = 1,
    //                Date = DateTime.Now,
    //                Temperature = 12.5,
    //                CityId = 1,
    //                ForecasterId = 1,
    //            },
    //            new FactualWeatherPrediction
    //            {
    //                Id = 2,
    //                Date = DateTime.Now.AddDays(-1),
    //                Temperature = 11.2,
    //                CityId = 1,
    //                ForecasterId = 1
    //            },
    //            new FactualWeatherPrediction
    //            {
    //                Id = 3,
    //                Date = DateTime.Now,
    //                Temperature = 10.2,
    //                CityId = 2,
    //                ForecasterId = 1
    //            }
    //        );            
    //    }
    //}
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