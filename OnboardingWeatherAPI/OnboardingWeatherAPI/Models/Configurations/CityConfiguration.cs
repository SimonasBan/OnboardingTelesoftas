﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnboardingWeatherAPI.Models.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            //builder.HasO
            //builder.HasOne(e => e.City)
            //    .WithOne(e => e.BbcForecasterData)
            //    .(e => e.CityId);
        }
    }
}
