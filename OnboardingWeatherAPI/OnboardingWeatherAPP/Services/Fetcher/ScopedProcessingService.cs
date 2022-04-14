using OnboardingWeatherAPI.Services;

namespace OnboardingWeather.Aplication.Services.Fetcher
{
    public interface IScopedProcessingService
    {
        Task DoWork(CancellationToken stoppingToken);
    }

    public class ScopedProcessingService : IScopedProcessingService
    {
        private int executionCount = 0;
        private readonly OpenWeatherWeatherService _openWeatherService;

        public ScopedProcessingService(OpenWeatherWeatherService openWeatherService)
        {
            _openWeatherService = openWeatherService;
        }

        public async Task DoWork(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                executionCount++;

                var forecast = await _openWeatherService.GetCurrentWeatherAsync();
                var forecastTemp = (string)forecast["main"]["temp"];
                Console.WriteLine($"Test Hosted service. Temperature {forecastTemp}");

                await Task.Delay(2000, stoppingToken);
            }
        }
    }
}
