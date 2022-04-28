using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using OnboardingWeatherAPI.Models.Shared;
using Microsoft.EntityFrameworkCore;
using OnboardingWeatherAPI.Services;
using OnboardingWeather.Aplication.Services;
using OnboardingWeather.Aplication.Services.Fetcher;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddHttpClient("OpenWeather", httpClient =>
{
    httpClient.BaseAddress = new Uri("https://api.openweathermap.org/data/");
});


builder.Services.AddScoped<CityWeatherService>();
builder.Services.AddScoped<OpenWeatherWeatherService>();
builder.Services.AddScoped<CityService>();
builder.Services.AddHostedService<ConsumeScopedServiceHostedService>();
builder.Services.AddScoped<IScopedProcessingService, ScopedProcessingService>();

//FOR multiple dependency injection
builder.Services.Scan(scan => scan
              .FromAssemblyOf<IWeatherForecastService>()
                .AddClasses(classes => classes.AssignableTo<IWeatherForecastService>())
                    .AsImplementedInterfaces()
                    .WithTransientLifetime()
            );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
