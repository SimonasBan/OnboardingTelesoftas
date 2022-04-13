using OnboardingWeatherAPI.Models;
using OnboardingWeatherAPI.Models.Shared;
using System.Xml;

namespace OnboardingWeatherAPI.Services
{
    public class BBCWeatherService
        //: IWeatherForecastService
    {
        private readonly ApplicationDbContext _context;
        public BBCWeatherService(ApplicationDbContext context)
        {
            _context = context;
        }
        //public double GetCurrentWeatherByCity(City city)
        //{
        //    if (city.BbcForecasterData != null)
        //    {
        //        ReadXml(city.BbcForecasterData.RssCode);
        //    }
        //    //city.BbcForecasterData.RssCode
        //    return 1;
        //}

        //private void ReadXml(string rssCode)
        //{
        //    var urlString = "https://weather-broker-cdn.api.bbci.co.uk/en/forecast/rss/3day/";
        //    urlString += rssCode;

        //    var reader = new XmlTextReader(urlString);
        //    string tempString;
        //    while (reader.Read())
        //    {
        //        tempString = reader.Name;
        //    }
        //}
    }
}
