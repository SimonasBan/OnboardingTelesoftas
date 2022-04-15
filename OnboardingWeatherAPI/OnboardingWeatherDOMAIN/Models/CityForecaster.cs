using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using OnboardingWeatherAPI.Models;

namespace OnboardingWeatherDOMAIN.Models
{
    public class CityForecaster
    {
        //TODO: Think about how more cities or more forecasters can be added
        /*Ideas:
         * form,
         * Add a file with cities
         */

        //TODO: providerCityId
        public string AcceessItem { get; set; }

        public long CityId { get; set; }
        public City City { get; set; }

        public long ForecasterId { get; set; }
        public Forecaster Forecaster { get; set; }
    }
}
