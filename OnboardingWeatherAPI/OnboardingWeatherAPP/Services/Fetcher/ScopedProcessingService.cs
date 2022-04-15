using OnboardingWeatherAPI.Services;

namespace OnboardingWeather.Aplication.Services.Fetcher
{
    public interface IScopedProcessingService
    {
        Task DoWork(CancellationToken stoppingToken);
    }

    public class ScopedProcessingService : IScopedProcessingService
    {
        //private readonly int Delay = 90000000;
        private readonly int Delay = 2000;
        //private readonly OpenWeatherWeatherService _openWeatherService;

        //TODO: list inject. Then iterate.
        private readonly IEnumerable<IWeatherForecastService> _weatherServices;

        public ScopedProcessingService(/*OpenWeatherWeatherService openWeatherService,*/ IEnumerable<IWeatherForecastService> weatherServices)
        {
            //_openWeatherService = openWeatherService;
            _weatherServices = weatherServices;
        }

        public async Task DoWork(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(Delay, stoppingToken);

                //TODO: implement for different services. With interface
                //

                
                foreach (var service in _weatherServices)
                {
                    Console.WriteLine("Test");
                    //await service.GetCurrentWeatherForCity();
                }
                Console.WriteLine("---");
                //var forecast = await _openWeatherService.GetCurrentWeatherForCity();
                //var forecastTemp = (string)forecast["main"]["temp"];
                //Console.WriteLine($"Test Hosted service. Temperature {forecastTemp}");


            }
        }
    }
}
