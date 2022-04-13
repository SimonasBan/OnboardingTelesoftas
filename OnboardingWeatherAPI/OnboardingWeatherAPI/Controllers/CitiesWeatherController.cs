using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnboardingWeatherAPI.Models;
using OnboardingWeatherAPI.Models.Shared;
using OnboardingWeatherAPI.Services;
//using OnboardingWeatherDOMAIN.Models;

namespace OnboardingWeatherAPI.Controllers
{
    [Route("cities")]
    [ApiController]
    public class CitiesWeatherController : ControllerBase
    {
        //injection in startup
        private readonly ApplicationDbContext _context;
        private readonly CityWeatherService _cityWeather;
        private readonly BBCWeatherService _forecastService;
        public CitiesWeatherController(ApplicationDbContext context, CityWeatherService cityWeather,
            BBCWeatherService forecastService)
        {
            _context = context;
            _cityWeather = cityWeather;
            _forecastService = forecastService;
        }
        //Get a list of available cities;    ---    GET /cities
        [HttpGet]
        public async Task<IEnumerable<string>?> GetAvailableCities()
        {
            return await _cityWeather.GetAvailableCitiesNames();
            //return await _context.Cities.Select
            //    (e => e.Name).ToListAsync();
        }

        //[HttpGet("testRss")]
        //public double TestRss()
        //{
        //    var res = _forecastService.GetCurrentWeatherByCity(_context.Cities.Find((long)4));
        //    return res;
        //    //return await _context.Cities.Select
        //    //    (e => e.Name).ToListAsync();
        //}

        //[HttpGet("fill-db")]
        //public bool FillDatabase()
        //{
        //    //Cities
        //    var kaunas = new City
        //    {
        //        Name = "Kaunas"
        //    };
        //    _context.Cities.Add(kaunas);
        //    var tbilisi = new City
        //    {
        //        Name = "Tbilisi"
        //    };
        //    _context.Cities.Add(tbilisi);
        //    _context.SaveChanges();

        //    ////BbcForecasterData
        //    //var tbilisiFromDb = _context.Cities.Where(e => e.Name == "Tbilisi").First();
        //    //var tbilisiBbcForecasterData = new BbcForecasterData
        //    //{
        //    //    RssCode = "611717",
        //    //};
        //    //tbilisiBbcForecasterData.City = tbilisiFromDb;
        //    //_context.BbcForecasterDatas.Add(tbilisiBbcForecasterData);
        //    //_context.SaveChanges();




        //    //--------
        //    //--------
        //    //--------

        //    //modelBuilder.Entity<BbcForecasterData>().HasData(
        //    //    new BbcForecasterData
        //    //    {
        //    //        Id = 1,
        //    //        RssCode = "611717"
        //    //    }
        //    //);

        //    ////Forecaster seed
        //    //var openWeather = new Forecaster
        //    //{
        //    //    Id = 1,
        //    //    Name = "OpenWeatherMap"
        //    //};

        //    //modelBuilder.Entity<Forecaster>().HasData(
        //    //    openWeather
        //    //);
        //    ////FactualWeatherPrediction seed
        //    //modelBuilder.Entity<FactualWeatherPrediction>().HasData(
        //    //    new FactualWeatherPrediction
        //    //    {
        //    //        Id = 1,
        //    //        Date = DateTime.Now,
        //    //        Temperature = 12.5,
        //    //        CityId = 1,
        //    //        ForecasterId = 1,
        //    //    },
        //    //    new FactualWeatherPrediction
        //    //    {
        //    //        Id = 2,
        //    //        Date = DateTime.Now.AddDays(-1),
        //    //        Temperature = 11.2,
        //    //        CityId = 1,
        //    //        ForecasterId = 1
        //    //    },
        //    //    new FactualWeatherPrediction
        //    //    {
        //    //        Id = 3,
        //    //        Date = DateTime.Now,
        //    //        Temperature = 10.2,
        //    //        CityId = 2,
        //    //        ForecasterId = 1
        //    //    }
        //    //);
        //    return true;
        //}

        //[HttpGet("get-test-forecaster")]
        //public bool GetTestForecaster()
        //{
        //    var testForecaster = _context.BbcForecasterDatas.First();

        //    return true;
        //}

        //Get a list of available dates for the city;    ---    GET /cities/1/dates
        [HttpGet("{id}/dates")]
        public IEnumerable<string> GetAvailableDatesForCity([FromRoute] long id)
        {
            var cities = new List<string>();
            cities.Add($"Kaunas ID = {id}");
            return cities;
        }


        //Get a list of average factual (combined from all third party data in a city) temperature for a given date range by day;
        //---    GET /cities/1/factualTemperatures?from-date=N&to-date=N
        [HttpGet("{id}/factual-temperatures")]
        public string GetAverageFactualTemperaturesForCityByDate([FromRoute] long id, [FromQuery] string fromDate,[FromQuery] string toDate)
        {
            return $"From {fromDate}, to {toDate}";
        }

        //Get each forecaster’s stdev compared to factual temperature measurements for each day in a given date range in a city;
        //---    GET /cities/1/stedv?from-date=N&to-date=N
        [HttpGet("{id}/stdev")]
        public string GetAllForecastersStandardDeviationsForCityByDate([FromRoute] long id, [FromQuery] string fromDate, [FromQuery] string toDate)
        {
            return $"stdev for city with ID = {id}, From {fromDate}, to {toDate}";
        }

        //Get collected data for a given date range in a city by day: each forecaster's reported factual temperatures and predictions;
        //---GET /cities/1/collected-data?from-date=N&to-date=N
        [HttpGet("{id}/collected-data")]
        public string GetCollectedDataForCityByDate([FromRoute] long id, [FromQuery] string fromDate, [FromQuery] string toDate)
        {
            return $"Collected data for city with ID = {id}, From {fromDate}, to {toDate}";
        }

    }
}
//Su HTTP codes susipazint
//Jei ka, tai toliau servisus
