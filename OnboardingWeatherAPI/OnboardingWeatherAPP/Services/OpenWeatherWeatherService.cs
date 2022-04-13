using Newtonsoft.Json.Linq;
using OnboardingWeatherAPI.Models;
using OnboardingWeatherAPI.Models.Shared;
using System.Net;
using System.Xml;

namespace OnboardingWeatherAPI.Services
{
    public class OpenWeatherWeatherService
        //: IWeatherForecastService
    {
        private const string ApiKey = "c5f241ad2670a83cc3b38551c15cbd4f";
        private readonly ApplicationDbContext _context;
        public OpenWeatherWeatherService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<JObject> GetCurrentWeatherAsync()
        {
            var cityCode = "Kaunas"; 
            var url = $"https://api.openweathermap.org/data/2.5/weather?q={cityCode}&appid={ApiKey}";

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url)
            };

            HttpClient client = new HttpClient();
            var response = await client.SendAsync(request).ConfigureAwait(false);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return null;
            }
            else
            {
                var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var responseJson = JObject.Parse(responseBody);
                return responseJson;
            }
        }
    }
}
