﻿using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfaces
{
    public interface IWeatherService
    {
        Task<CityWeatherModel> GetCityWeather(int cityId);
    }
}
