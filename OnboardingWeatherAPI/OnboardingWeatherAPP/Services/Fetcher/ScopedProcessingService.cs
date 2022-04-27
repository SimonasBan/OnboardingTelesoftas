using OnboardingWeatherAPI.Services;

namespace OnboardingWeather.Aplication.Services.Fetcher
{
    public interface IScopedProcessingService
    {
        Task DoWork(CancellationToken stoppingToken);
    }

    public class ScopedProcessingService : IScopedProcessingService
    {
        private readonly int Delay = 86400;

        private readonly CityService _cityService;
        private readonly IEnumerable<IWeatherForecastService> _weatherServices;

        public ScopedProcessingService(CityService cityService, IEnumerable<IWeatherForecastService> weatherServices)
        {
            _cityService = cityService;
            _weatherServices = weatherServices;
        }

        public async Task DoWork(CancellationToken stoppingToken)
        {
            //TODO: Register if all service's exists->foreach

            while (!stoppingToken.IsCancellationRequested)
            {
                Console.WriteLine("Start hosted service");
                await Task.Delay(Delay, stoppingToken);

                var citiesIds = await _cityService.GetAllCitiesIds();

                if (citiesIds != null)
                {
                    foreach (var service in _weatherServices)
                    {                     
                        foreach (var cityId in citiesIds)
                        {
                            //TODO: !!Get  forecast also
                            await service.AddTodaysFactualWeatherForCity(cityId);
                        }
                    }
                }          
            }
        }
    }
}
