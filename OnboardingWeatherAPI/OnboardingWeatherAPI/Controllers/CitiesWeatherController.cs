﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using OnboardingWeatherAPI.Models;
using OnboardingWeatherAPI.Models.Shared;
using OnboardingWeatherAPI.Services;
using OnboardingWeatherDOMAIN.Models;
using System.Text;
//using OnboardingWeatherDOMAIN.Models;

namespace OnboardingWeatherAPI.Controllers
{
    [Route("cities")]
    [ApiController]
    public class CitiesWeatherController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly CityWeatherService _cityWeather;
        private readonly IEnumerable<IWeatherForecastService> _weatherServices;
        public CitiesWeatherController(ApplicationDbContext context, CityWeatherService cityWeather
            , IEnumerable<IWeatherForecastService> weatherServices)
        {
            _context = context;
            _cityWeather = cityWeather;
            _weatherServices = weatherServices;
        }

        //Get a list of average factual (combined from all third party data in a city) temperature for a given date range by day;
        //---    GET /cities/1/factualTemperatures?from-date=N&to-date=N
        [HttpGet("{id}/factual-temperatures")]
        public ActionResult<JObject> GetAverageFactualTemperaturesForCityByDate([FromRoute] long id, [FromQuery] string fromDate, [FromQuery] string toDate)
        {
            //get city
            //getAverageFactualByCityAndDate(city, dates):
                //get IWeather.GetfactualTempsByCityByDate(city, dates)

            return NotFound();
        }

        //Get a list of available cities;    ---    GET /cities
        [HttpGet]
        public async Task<IEnumerable<string>?> GetAvailableCities()
        {
            return await _cityWeather.GetAvailableCitiesNames();
            //return await _context.Cities.Select
            //    (e => e.Name).ToListAsync();
        }      

        //Get a list of available dates for the city;    ---    GET /cities/1/dates
        [HttpGet("{id}/dates")]
        public IEnumerable<string> GetAvailableDatesForCity([FromRoute] long id)
        {
            var cities = new List<string>();
            cities.Add($"Kaunas ID = {id}");
            return cities;
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

        //---fb fillls and tests
        //[HttpGet("test-add-factual-prediction")]
        //public bool TestAddFactualPrediction()
        //{
        //    var kaunasFromDb = _context.Cities
        //        .Where(x => x.Name == "Kaunas").First();

        //    var facturalPrediction = new FactualWeatherPrediction
        //        {
        //            City = kaunasFromDb,
        //            Date = DateTime.Now,
        //            Temperature = 21.5,
        //        };

        //    _context.FactualPredictions.Add(facturalPrediction);
        //    _context.SaveChanges();

        //    return true;
        //}


        //[HttpGet("test-fill-City-Forecaster")]
        //public bool TestFillCityForecaster()
        //{
        //    //Define many to many
        //    var kaunasFromDb = _context.Cities
        //        .Where(x => x.Name == "Kaunas").First();

        //    var openWeatherFromDb = _context.Forecasters
        //        .Where(x => x.Name == "OpenWeather").First();

        //    _context.CityForecasters.Add(new CityForecaster {
        //        City = kaunasFromDb,
        //        Forecaster = openWeatherFromDb,
        //        AcceessItem = "test"
        //    });
        //    _context.SaveChanges();
        //    return true;
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

        //    //Forecasters
        //    _context.Forecasters.Add(new Forecaster
        //    {
        //        Name = "OpenWeather",
        //    });
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

    }
}
//Su HTTP codes susipazint
//Jei ka, tai toliau servisus
