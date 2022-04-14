using OnboardingWeatherAPI.Models;
using OnboardingWeatherAPI.Models.Shared;
using OnboardingWeatherAPI.Services;

namespace OnboardingWeather.Aplication.Services
{
    public class FetchForecastHostedService : BackgroundService
    {
        private readonly OpenWeatherWeatherService _openWeatherService;
        //private readonly ApplicationDbContext _context;
        public FetchForecastHostedService(/*ApplicationDbContext context, */
            OpenWeatherWeatherService openWeatherService)
        {
            _openWeatherService = openWeatherService;
            //_context = context;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {                
                await Task.Delay(2000, stoppingToken);

                //var forecast = await _openWeatherService.GetCurrentWeatherAsync();
                //var forecastTemp = (string)forecast["main"]["temp"];
                //Console.WriteLine($"Test Hosted service. Temperature {forecastTemp}");
            }

            
            //var fakeCity = new City
            //{
            //    Name = forecastTemp,
            //};
            //_context.Cities.Add(fakeCity);
            //_context.SaveChangesAsync();            
        }
    }
}
