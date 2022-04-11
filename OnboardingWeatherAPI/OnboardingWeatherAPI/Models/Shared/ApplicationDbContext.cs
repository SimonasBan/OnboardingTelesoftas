using System.Data.Entity;

namespace OnboardingWeatherAPI.Models.Shared
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<City> City { get; set; }
    }
}
