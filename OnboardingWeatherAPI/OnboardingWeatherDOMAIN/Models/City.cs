using OnboardingWeatherDOMAIN.Models;

namespace OnboardingWeatherAPI.Models
{
    public class City
    {
        public City()
        {
            //FactualWeatherPredictions = new HashSet<FactualWeatherPrediction>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        //ISO code??

        public ICollection<FactualWeatherPrediction> FactualWeatherPredictions { get; set; }
        public BbcForecasterData? BbcForecasterData { get; set; }
        //public ForecastServiceData
        //->ICollection<CityForecasterData>
    }
}

//CityForecasterData model:
//->City
//->Forecaster
//Connection string??. Have method, which would parse depending on resource?


//Can model be as an interface?


