﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnboardingWeatherAPI.Models;
using OnboardingWeatherAPI.Models.Shared;
using OnboardingWeatherAPI.Services;

namespace OnboardingWeatherAPI.Controllers
{
    [Route("cities")]
    [ApiController]
    public class CitiesWeatherController : ControllerBase
    {
        //injection in startup
        private readonly ApplicationDbContext _context;
        private readonly CityWeatherService _cityWeather;
        public CitiesWeatherController(ApplicationDbContext context, CityWeatherService cityWeather)
        {
            _context = context;
            _cityWeather = cityWeather;
        }
        //Get a list of available cities;    ---    GET /cities
        [HttpGet]
        public async Task<IEnumerable<string>?> GetAvailableCities()
        {
            //var citiesNames = await _cityWeather.GetAvailableCitiesNames();
            return await _context.Cities.Select
                (e => e.Name).ToListAsync();
        }

        //Method for testing out db seed problem
        [HttpGet("db")]
        public async Task<bool> FillDb()
        {
            _context.FactualWeatherPredictions.Add(new FactualWeatherPrediction
            {
                //Id = 1,
                Date = DateTime.Now,
                Temperature = 12.5,
                City = _context.Cities.First(),
                Forecaster = _context.Forecasters.First()
            });
            await _context.SaveChangesAsync();
            return true;
        }

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
