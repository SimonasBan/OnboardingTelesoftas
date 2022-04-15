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

        //TODO: list inject. Then iterate.
        private readonly CityService _cityService;
        private readonly IEnumerable<IWeatherForecastService> _weatherServices;
        

        public ScopedProcessingService(CityService cityService, IEnumerable<IWeatherForecastService> weatherServices)
        {
            _cityService = cityService;
            _weatherServices = weatherServices;
        }

        public async Task DoWork(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(Delay, stoppingToken);


                //Get cities ID's
                var citiesIds = await _cityService.GetAllCitiesIds();

                if (citiesIds != null)
                {
                    //TODO: implement for different services. With interface
                    //
                    foreach (var service in _weatherServices)
                    {
                        Console.WriteLine("Test");
                        foreach (var cityId in citiesIds)
                        {
                            //await service.GetCurrentWeatherForCity(cityId);
                        }
                    }
                }


                Console.WriteLine("---");
                //var forecast = await _openWeatherService.GetCurrentWeatherForCity();
                //var forecastTemp = (string)forecast["main"]["temp"];
                //Console.WriteLine($"Test Hosted service. Temperature {forecastTemp}");
                

            }
        }
    }
}
