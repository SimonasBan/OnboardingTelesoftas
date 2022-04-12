using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnboardingWeatherAPI.Models.Configurations
{
    public class FactualWeatherPredictionConfiguration : IEntityTypeConfiguration<FactualWeatherPrediction>
    {
        public void Configure(EntityTypeBuilder<FactualWeatherPrediction> builder)
        {           
            builder.HasOne(e => e.City)
                .WithMany(e => e.FactualWeatherPredictions)
                .HasForeignKey(e => e.CityId);

            builder.HasOne(e => e.Forecaster)
                .WithMany(e => e.FactualWeatherPredictions)
                .HasForeignKey(e => e.ForecasterId);
        }
    }
}
