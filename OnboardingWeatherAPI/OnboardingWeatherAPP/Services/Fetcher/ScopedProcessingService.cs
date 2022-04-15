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

        private readonly CityService _cityService;
        private readonly IEnumerable<IWeatherForecastService> _weatherServices;
        //TODO:---- use lib scrutor instead

        public ScopedProcessingService(CityService cityService, IEnumerable<IWeatherForecastService> weatherServices)
        {
            _cityService = cityService;
            _weatherServices = weatherServices;
        }

        public async Task DoWork(CancellationToken stoppingToken)
        {
            //Register if all service's exists->foreach

            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(Delay, stoppingToken);


                //Get cities ID's
                var citiesIds = await _cityService.GetAllCitiesIds();

                if (citiesIds != null)
                {
                    foreach (var service in _weatherServices)
                    {                     

                        Console.WriteLine("Service");
                        foreach (var cityId in citiesIds)
                        {
                            Console.WriteLine("---and_city");
                            await service.AddTodaysFactualWeatherForCity(cityId);
                        }
                    }
                }


                Console.WriteLine("---");
                

            }
        }
    }
}
