﻿using OnboardingWeatherAPI.Models;

namespace OnboardingWeatherDOMAIN.Models
{
    public class BbcForecasterData
    {
        public long Id { get; set; }
        public long RssCode { get; set; }

        public City City { get; set; }
        public long CityId { get; set; }
    }
}