using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using OnboardingWeatherAPI.Models.Shared;
using OnboardingWeatherAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using OnboardingWeatherAPI.Services;
using OnboardingWeather.Aplication.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSq);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//builder.Services.AddScoped<CityWeatherService>();
//builder.Services.AddScoped<OpenWeatherWeatherService>();
builder.Services.AddHostedService<FetchForecastHostedService>();

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

//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;

//    var context = services.GetRequiredService<ApplicationDbContext>();
//    context.Database.EnsureCreated();
//    // DbInitializer.Initialize(context);
//}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
