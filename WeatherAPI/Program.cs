using Business.Services;
using Business.Services.Interfaces;
using Business.Utility;
using Data;
using Data.Repository;
using Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options => 
            options.UseSqlServer(builder.Configuration.GetConnectionString("WeatherAppConnection")));

builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<IWeatherHistoryRepository, WeatherHistoryRepository>();
builder.Services.AddScoped<IStatisticsRepository, StatisticsRepository>();


builder.Services.AddScoped<IWeatherUtility, WeatherUtility>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<IWeatherService, WeatherService>();
builder.Services.AddScoped<IWeatherHistoryService, WeatherHistoryService>();
builder.Services.AddScoped<IColdestDayStatisticsService, ColdestDayStatisticsService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
