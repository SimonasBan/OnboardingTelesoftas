//using OnboardingWeatherDOMAIN.Models;

namespace OnboardingWeatherAPI.Models
{
    public class City
    {
        public long Id { get; set; }
        public string Name { get; set; }

        //public ICollection<FactualWeatherPrediction> FactualWeatherPredictions { get; set; }
        //public BbcForecasterData? BbcForecasterData { get; set; }
    }
}

//CityForecasterData model:
//->City
//->Forecaster
//Connection string??. Have method, which would parse depending on resource?


//Can model be as an interface?


