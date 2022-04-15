using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using OnboardingWeatherAPI.Models;
using OnboardingWeatherAPI.Models.Shared;
using System.Net;
using System.Xml;

namespace OnboardingWeatherAPI.Services
{
    public class OpenWeatherWeatherService : IWeatherForecastService
    //: IWeatherForecastService
    {
        private readonly IConfiguration Configuration;
        private readonly ApplicationDbContext _context;
        private readonly IHttpClientFactory _httpClientFactory;

        public OpenWeatherWeatherService(ApplicationDbContext context, IHttpClientFactory httpClientFactory
            , IConfiguration configuration)
        {
            _context = context;
            _httpClientFactory = httpClientFactory;
            Configuration = configuration;
        }
        public async Task<bool> AddTodaysFactualWeatherForCity(long cityId)
        {
            Console.WriteLine("OpenWeather service action");
            //--------
            var city = await _context.Cities
                .Include(e => e.CityForecasters)
                    .ThenInclude(e => e.Forecaster)
                .Where(x => x.Id == cityId)
                .FirstOrDefaultAsync();
            //TODO: search from CityForecasters with composite keys

            if (city.CityForecasters == null)
            {
                return false;
            }

            var cityCode = city.CityForecasters
                .Where(e => e.Forecaster.Name == "OpenWeather")
                .Select(e => e.AcceessItem)
                .FirstOrDefault();
            //-----client part----

            var apiKey = Configuration["OpenWeatherAPI:ApiKey"];
            var apiVersion = Configuration["OpenWeatherAPI:Version"];

            var httpClient = _httpClientFactory.CreateClient("OpenWeather");
            var response = await httpClient.GetAsync($"{apiVersion}/weather?q={cityCode}&appid={apiKey}");

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return false;
            }

            //TODO: response model to parse
            var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var responseJson = JObject.Parse(responseBody);
            var temperature = (double)responseJson["main"]["temp"];

            var factualPrediction = new FactualWeatherPrediction
            {
                Temperature = temperature,
                City = city,
                Date = DateTime.UtcNow
            };

            _context.FactualPredictions.Add(factualPrediction);
            await _context.SaveChangesAsync();     
            
            //TODO: return only factual prediction and higher service adds to db
            return true;
        }
    }
}
