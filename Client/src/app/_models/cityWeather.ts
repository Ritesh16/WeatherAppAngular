export interface CityWeather{ 
  cityId: number
  cityName: string
  stateName: string
  dateTime: string
  weatherModel: Weather
}

export interface Weather {
    lat: number
    lon: number
    timezone: string
    timezone_offset: number
    current: CurrentWeather
    minutely: Minutely[]
    hourly: Hourly[]
    daily: Daily[]
    alerts: any[]
    statement: string
  }
  
  export interface CurrentWeather {
    dt: number
    sunrise: number
    sunset: number
    temp: number
    feels_like: number
    pressure: number
    humidity: number
    dew_point: number
    uvi: number
    clouds: number
    visibility: number
    wind_speed: number
    wind_deg: number
    wind_gust: number
    weather: WeatherDescription[]
  }
  
  export interface WeatherDescription {
    id: number
    main: string
    description: string
    icon: string
  }
  
  export interface Minutely {
    dt: number
    precipitation: number
  }
  
  export interface Hourly {
    dt: number
    temp: number
    feels_like: number
    pressure: number
    humidity: number
    dew_point: number
    uvi: number
    clouds: number
    visibility: number
    wind_speed: number
    wind_deg: number
    wind_gust: number
    weather: WeatherDescription[]
    pop: number
  }
  
  export interface Daily {
    dt: number
    sunrise: number
    sunset: number
    moonrise: number
    moonset: number
    moon_phase: number
    temp: Temp
    feels_like: FeelsLike
    pressure: number
    humidity: number
    dew_point: number
    wind_speed: number
    wind_deg: number
    wind_gust: number
    weather: WeatherDescription[]
    clouds: number
    pop: number
    uvi: number
    rain?: number
  }
  
  export interface Temp {
    day: number
    min: number
    max: number
    night: number
    eve: number
    morn: number
  }
  
  export interface FeelsLike {
    day: number
    night: number
    eve: number
    morn: number
  }

  