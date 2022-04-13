using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnboardingWeatherDOMAIN.Models;

namespace OnboardingWeatherAPI.Models.Configurations
{
    public class BbcForecasterDataConfiguration : IEntityTypeConfiguration<BbcForecasterData>
    {
        public void Configure(EntityTypeBuilder<BbcForecasterData> builder)
        {
            //builder.HasOne(e => e.City)
            //    .WithOne(e => e.BbcForecasterData)
            //    .(e => e.CityId);
        }
    }
}
