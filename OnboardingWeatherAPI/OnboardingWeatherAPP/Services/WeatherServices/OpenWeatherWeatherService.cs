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
        //TODO: to appsettings
        private const string ApiKey = "c5f241ad2670a83cc3b38551c15cbd4f";
        private readonly ApplicationDbContext _context;
        public OpenWeatherWeatherService(ApplicationDbContext context)
        {
            _context = context;
        }
        public string GetCurrentWeatherForCity(/*long cityId*/)
        {
            //var city = await _context.Cities
            //    .Include(e => e.CityForecasters)
            //    .Where(x => x.Id == cityId)
            //    .FirstOrDefaultAsync();

            //if(city.CityForecasters == null)
            //{
            //    return null;
            //}

            ////TODO: left here
            //var cityCode = city.CityForecasters
            //    .Where(e => e.Forecaster.Name == "OpenWeather")
            //    .Select(e => e.AcceessItem)
            //    .FirstOrDefault();


            //var url = $"https://api.openweathermap.org/data/2.5/weather?q={cityCode}&appid={ApiKey}";

            //var request = new HttpRequestMessage
            //{
            //    Method = HttpMethod.Get,
            //    RequestUri = new Uri(url)
            //};

            ////TODO: move client to a service. Factory with api base, key etc. HTTPClient factory.
            //HttpClient client = new HttpClient();
            //var response = await client.SendAsync(request).ConfigureAwait(false);

            //if (response.StatusCode != HttpStatusCode.OK)
            //{
            //    return null;
            //}
            //else
            //{
            //    var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            //    var responseJson = JObject.Parse(responseBody);
            //    return responseJson;
            //}
            Console.WriteLine("OpenWeather service action");
            return "OpenWeather";
        }
    }
}
